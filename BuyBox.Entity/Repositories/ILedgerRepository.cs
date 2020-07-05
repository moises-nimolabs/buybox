using System.Collections.Generic;
using System.Threading.Tasks;
using BuyBox.Data.Entities;

namespace BuyBox.Data.Repositories
{
    /// <summary>
    ///     Performs the most common the Ledger operations.
    /// </summary>
    public interface ILedgerRepository
    {
        /// <summary>
        ///     Inserts a single Token for the given session
        /// </summary>
        /// <param name="tokenId">Token code to be used</param>
        /// <param name="session">User session to be considered in the end</param>
        Task<Token> InsertToken(string tokenId, string session);

        /// <summary>
        ///     Cancels the given session transaction completely
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        Task<IEnumerable<Token>> CancelAndRetrieveInserted(string sessionId);

        /// <summary>
        ///     Retrieves without removing the user added <see cref="Token" />'s
        ///     for the current session.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns>A List of <see cref="LedgerEntry" /> items containing token information</returns>
        Task<IEnumerable<LedgerEntry>> GetAddedCollectionBySession(string sessionId);

        /// <summary>
        ///     Subtracts a <see cref="Token" /> from the user
        ///     by inserting a new <see cref="LedgerEntry" /> in the system.
        /// </summary>
        /// <param name="sessionId">The underlying user session</param>
        /// <param name="priceToSubtract">The price to be subtracted</param>
        /// <returns></returns>
        Task<IEnumerable<LedgerEntry>> Subtract(string sessionId, double priceToSubtract);

        /// <summary>
        ///     Retrieves the possible exchange tokens from the system.
        /// </summary>
        /// <returns></returns>
        Task<IList<ExchangeToken>> GetExchangeTokens();

        /// <summary>
        ///     Adds the selected exchange tokens to the user.
        ///     This operation will get random tokens that might be available in the system.
        /// </summary>
        /// <param name="sessionId">User <see cref="Session" /> Id</param>
        /// <param name="tokensToExchange">Exchange token Collection to be compared and give back</param>
        /// <returns></returns>
        Task AddExchangeTokens(string sessionId, IEnumerable<ExchangeToken> tokensToExchange);
    }
}