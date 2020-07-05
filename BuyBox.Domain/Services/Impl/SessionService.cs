using System.Threading.Tasks;
using AutoMapper;
using BuyBox.Data.Repositories;
using BuyBox.Domain.Models;

namespace BuyBox.Domain.Services.Impl
{
    public class SessionService : ISessionService
    {
        private readonly IMapper _mapper;
        private readonly ISessionRepository _sessionRepository;

        public SessionService(IMapper mapper, ISessionRepository sessionRepository)
        {
            _mapper = mapper;
            _sessionRepository = sessionRepository;
        }

        public async Task<SessionModel> New()
        {
            var entity = await _sessionRepository.New();
            return _mapper.Map<SessionModel>(entity);
        }

        public async Task<SessionModel> Finish(string id)
        {
            var entity = await _sessionRepository.Finish(id);
            return _mapper.Map<SessionModel>(entity);
        }
    }
}