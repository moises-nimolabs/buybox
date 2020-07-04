using System.Collections.Generic;
using System.Threading.Tasks;
using BuyBox.Data.Entities;

namespace BuyBox.Data.Repositories
{
    public interface ISellableItemRepository
    {
        Task<IEnumerable<SellableItem>> List();
    }
}