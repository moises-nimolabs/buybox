using System.Collections.Generic;
using System.Threading.Tasks;
using BuyBox.Data.Entities;
using BuyBox.Data.Impl;
using Microsoft.EntityFrameworkCore;

namespace BuyBox.Data.Repositories.Impl
{
    public class SellableItemRepository : ISellableItemRepository
    {
        private BuyBoxDbContext _dbContext;

        public SellableItemRepository(BuyBoxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SellableItem>> List()
        {
            return await _dbContext.SellableItems.ToListAsync();
        }
    }
}