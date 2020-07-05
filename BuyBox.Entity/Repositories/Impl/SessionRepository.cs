using System;
using System.Threading.Tasks;
using BuyBox.Data.Entities;

namespace BuyBox.Data.Repositories.Impl
{
    public class SessionRepository : ISessionRepository
    {
        private readonly BuyBoxDbContext _dbContext;

        public SessionRepository(BuyBoxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Session> New()
        {
            var session = new Session
            {
                Id = Guid.NewGuid().ToString(),
                Started = new DateTime()
            };
            await _dbContext.Sessions.AddAsync(session);
            await _dbContext.SaveChangesAsync();
            return session;
        }

        public async Task<Session> Finish(string id)
        {
            var session = await _dbContext.Sessions.FindAsync(id);
            session.Finished = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return session;
        }
    }
}