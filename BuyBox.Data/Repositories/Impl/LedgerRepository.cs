using System.Linq;
using System.Threading.Tasks;
using BuyBox.Data.Entities;
using BuyBox.Data.Impl;
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
        public async Task InsertToken(string code, string session)
        {
            var token = _dbContext.Tokens.FirstOrDefault(p => p.Code == code);
            var ledgerEntry = new LedgerEntry()
            {
                Quantity = 1,
                Session = session,
                Token = token,
                Operation = "I"
            };
            
            await _dbContext.LedgerEntries.AddAsync(ledgerEntry);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Cancel(string sessionId)
        {
            await _dbContext.LedgerEntries.Include(i => i.Token).Where(p => p.Session == sessionId)
                .ForEachAsync(p =>
                {
                    var e = new LedgerEntry()
                    {
                        Session = sessionId,
                        Operation = "O",
                        Token = p.Token,
                        Quantity = p.Quantity
                    };
                    _dbContext.LedgerEntries.Add(e);
                });
            await _dbContext.SaveChangesAsync();
        }
    }
}