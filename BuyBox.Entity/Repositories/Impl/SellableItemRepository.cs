using System.Collections.Generic;
using System.Threading.Tasks;
using BuyBox.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuyBox.Data.Repositories.Impl
{
    public class SellableItemRepository : ISellableItemRepository
    {
        private readonly BuyBoxDbContext _dbContext;

        public SellableItemRepository(BuyBoxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SellableItem>> List()
        {
            return await _dbContext.SellableItems.ToListAsync();
        }

        public async Task<SellableItem> Find(int id)
        {
            return await _dbContext.SellableItems.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeductStock(SellableItem resultSellableItem)
        {
            var product = await _dbContext.Products.FindAsync(resultSellableItem.Id);
            var stockHistory = new StockEntry
            {
                Operation = "O",
                Product = product,
                Quantity = resultSellableItem.Quantity
            };
            await _dbContext.StockHistories.AddAsync(stockHistory);
            await _dbContext.SaveChangesAsync();
        }
    }
}