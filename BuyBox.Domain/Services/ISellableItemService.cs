using System.Threading.Tasks;
using BuyBox.Domain.Models;

namespace BuyBox.Domain.Services
{
    public interface ISellableItemService
    {
        Task<SellableItemModelCollection> GetCollection();
        Task<PurchaseModel> OrderItem(int id, string sessionId);
    }
}