using System.Collections.Generic;
using System.Threading.Tasks;
using BuyBox.Domain.Models;

namespace BuyBox.Domain.Services
{
    public interface ISellableItemService
    {
        Task<IEnumerable<SellableItemModel>> List();
    }
}