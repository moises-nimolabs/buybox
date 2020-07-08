using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyBox.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuyBox.Data.Repositories.Impl
{
    public class LedgerRepository : ILedgerRepository
    {
        private readonly BuyBoxDbContext _dbContext;

        public LedgerRepository(BuyBoxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Token> InsertToken(string tokenId, string sessionId)
        {
            var token = await _dbContext.Tokens.FindAsync(tokenId);
            var session = _dbContext.Sessions.FirstOrDefault(p => p.Id == sessionId);
            var ledgerEntry = new LedgerEntry
            {
                Session = session,
                Token = token,
                Operation = "I"
            };

            await _dbContext.LedgerEntries.AddAsync(ledgerEntry);
            await _dbContext.SaveChangesAsync();
            return token;
        }

        public async Task<IEnumerable<Token>> CancelAndRetrieveInserted(string sessionId)
        {
            var session = await _dbContext.Sessions.FirstOrDefaultAsync(p => p.Id == sessionId);
            //checking the added tokens
            var insertedTokens = _dbContext.LedgerEntries
                .Include(i => i.Session)
                .Include(i => i.Token)
                .Include(i => i.Related)
                .Where(p => p.Session.Id == sessionId && p.Operation == "I")
                .ToList();
            //checking if there is already a cancellation
            var excludedTokens = _dbContext.LedgerEntries
                .Include(r => r.Related)
                .Include(i => i.Token)
                .Where(p => p.Session.Id == sessionId && p.Operation == "O")
                .ToList();

            IList<Token> retrieved = new List<Token>();

            insertedTokens.ForEach(p =>
            {
                //need to make sure it won't happen
                //double cancellation
                var canceledEntry = excludedTokens.FirstOrDefault(c => c.Related.Id == p.Id);
                if (canceledEntry != null)
                    return;
                //if it's ok to cancel, generate a new ledger to keep track of the transaction
                var e = new LedgerEntry
                {
                    Session = session,
                    Related = p,
                    Token = p.Token,
                    Operation = "O"
                };
                _dbContext.LedgerEntries.Add(e);
                retrieved.Add(e.Token);
            });
            await _dbContext.SaveChangesAsync();
            return retrieved;
        }

        public async Task<IEnumerable<LedgerEntry>> GetAddedCollectionBySession(string sessionId)
        {
            var inserted = await _dbContext.LedgerEntries
                .Include(i => i.Session)
                .Include(i => i.Token)
                .Where(p => sessionId != null && p.Session.Id == sessionId && p.Operation == "I")
                .Select(s => s)
                .ToListAsync();

            var usedOrCancelled = await _dbContext.LedgerEntries
                .Include(i => i.Session)
                .Include(p => p.Token)
                .Include(i => i.Related)
                .Where(p => sessionId != null && p.Session.Id == sessionId && p.Operation == "O")
                .Select(s => s.Related)
                .ToListAsync();

            return inserted.Except(usedOrCancelled);
        }

        public async Task<IEnumerable<LedgerEntry>> Subtract(string sessionId, double priceToSubtract)
        {
            var session = await _dbContext.Sessions.FindAsync(sessionId);
            var inserted = await GetAddedCollectionBySession(sessionId);
            var ledgerEntries = inserted.ToList();
            var insertedOrdered = ledgerEntries.OrderBy(p => p.Token.Value).ToList();

            var currentPrice = priceToSubtract;

            IList<LedgerEntry> subtracted = new List<LedgerEntry>();

            var enumerator = insertedOrdered.GetEnumerator();
            while (currentPrice <= priceToSubtract && enumerator.MoveNext())
            {
                var currentLedgerEntry = enumerator.Current;
                if (currentLedgerEntry == null)
                    continue;
                currentPrice -= currentLedgerEntry.Token.Value;
                var newOutLedger = new LedgerEntry
                {
                    Operation = "O",
                    Related = currentLedgerEntry,
                    Session = session,
                    Token = currentLedgerEntry.Token
                };
                await _dbContext.LedgerEntries.AddAsync(newOutLedger);
                subtracted.Add(newOutLedger);
            }

            enumerator.Dispose();
            await _dbContext.SaveChangesAsync();
            return subtracted;
        }

        public async Task<IList<ExchangeToken>> GetExchangeTokens()
        {
            return await _dbContext.ExchangeTokens.OrderByDescending(o => o.Value).ToListAsync();
        }

        public async Task AddExchangeTokens(string sessionId, IEnumerable<ExchangeToken> tokensToExchange)
        {
            var session = await _dbContext.Sessions.FindAsync(sessionId);
            foreach (var t in tokensToExchange)
            {
                var ledgerEntry = await _dbContext.LedgerEntries
                    .Include(i => i.Token)
                    .Where(p => p.Token.Id == t.Id)
                    .Where(p => !_dbContext.LedgerEntries
                        .Include(i => i.Related)
                        .Where(sq => sq.Operation == "O")
                        .Select(s => s.Related.Id).Contains(p.Id)
                    )
                    .FirstOrDefaultAsync();


                var exchangedEntry = new LedgerEntry
                {
                    Operation = "O",
                    Session = session,
                    Related = ledgerEntry,
                    Token = ledgerEntry.Token
                };
                await _dbContext.AddAsync(exchangedEntry);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}