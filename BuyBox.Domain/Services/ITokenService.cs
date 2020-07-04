using System.Threading.Tasks;
using BuyBox.Domain.Models;

namespace BuyBox.Domain.Services
{
    /// <summary>
    /// Handles tokens interactions.
    /// </summary>
    public interface ITokenService
    {
        Task InsertCoin(CoinModel model);
        Task Cancel(string sessionId);
    }
}