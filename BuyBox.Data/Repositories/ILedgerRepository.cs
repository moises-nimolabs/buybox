using System.Threading.Tasks;
using BuyBox.Data.Entities;

namespace BuyBox.Data.Repositories
{
    /// <summary>
    /// Holds the Ledger operations.
    /// </summary>
    public interface ILedgerRepository
    {
        /// <summary>
        /// Inserts a single Token for the given session
        /// </summary>
        /// <param name="code">Token code to be used</param>
        /// <param name="session">User session to be considered in the end</param>
        Task InsertToken(string code, string session);
        /// <summary>
        /// Cancels the given session transaction completely
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        Task Cancel(string sessionId);
    }
}