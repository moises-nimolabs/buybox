using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuyBox.Data.Repositories;
using BuyBox.Domain.Models;

namespace BuyBox.Domain.Services.Impl
{
    /// <summary>
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly IMapper _mapper;
        private readonly ILedgerRepository _repository;

        public TokenService(IMapper mapper, ILedgerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TokenModelCollection> GetCollection(string sessionId)
        {
            var ledgerEntries = await _repository.GetAddedCollectionBySession(sessionId);
            var insertedTokens = ledgerEntries.Select(p => p.Token).ToList();
            return _mapper.Map<TokenModelCollection>(insertedTokens);
        }

        public async Task<TokenModel> InsertCoin(TokenModel model, string sessionId)
        {
            var token = await _repository.InsertToken(model.Id, sessionId);
            return _mapper.Map<TokenModel>(token);
        }

        public async Task<TokenModelCollection> CancelAndRetrieveInserted(string sessionId)
        {
            var retrieved = await _repository.CancelAndRetrieveInserted(sessionId);
            return _mapper.Map<TokenModelCollection>(retrieved);
        }
    }
}