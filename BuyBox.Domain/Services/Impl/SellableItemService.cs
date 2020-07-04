using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyBox.Data.Impl;
using BuyBox.Data.Repositories;
using BuyBox.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BuyBox.Domain.Services.Impl
{
    public class SellableItemService : ISellableItemService
    {
        private readonly ISellableItemRepository _repository;

        public SellableItemService(ISellableItemRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<SellableItemModel>> List()
        {
            var sellableItems = await _repository.List();
            return sellableItems.Select(p => new SellableItemModel()
            {
                Id = p.Id,
                Name = p.Name,
                Quantity = p.Quantity,
                Price = p.Price
            });
        }
    }
}