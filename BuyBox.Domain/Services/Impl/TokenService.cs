using System.Threading.Tasks;
using BuyBox.Data.Repositories;
using BuyBox.Domain.Models;

namespace BuyBox.Domain.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly ILedgerRepository _repository;
        
        public TokenService(ILedgerRepository repository)
        {
            _repository = repository;
        }
        
        public async Task InsertCoin(CoinModel model)
        {
            await _repository.InsertToken(model.Code, model.Session.Id);
        }

        public Task Cancel(string sessionId)
        {
            return _repository.Cancel(sessionId);
        }
    }
}