using System.Threading.Tasks;
using BuyBox.Domain.Models;

namespace BuyBox.Domain.Services
{
    /// <summary>
    ///     Handles tokens interactions.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        ///     Gets the user inserted tokens represented by a <see cref="TokenModelCollection" />
        /// </summary>
        /// <param name="sessionId">The underlying session</param>
        /// <returns></returns>
        Task<TokenModelCollection> GetCollection(string sessionId);

        /// <summary>
        ///     Inserts an user <see cref="TokenModel" />
        /// </summary>
        /// <param name="model">The <see cref="TokenModel" /> representation of Token</param>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        Task<TokenModel> InsertCoin(TokenModel model, string sessionId);

        /// <summary>
        ///     Cancels the user current session and retrieves his
        ///     inserted <see cref="TokenModel" />'s back
        /// </summary>
        /// <param name="sessionId">The underlying user <see cref="SessionModel" /> id</param>
        /// <returns>The refunded tokens</returns>
        Task<TokenModelCollection> CancelAndRetrieveInserted(string sessionId);
    }
}