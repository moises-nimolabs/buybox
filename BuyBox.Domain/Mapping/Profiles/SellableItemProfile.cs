using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BuyBox.Data.Entities;
using BuyBox.Domain.Models;

namespace BuyBox.Domain.Mapping.Profiles
{
    public class SellableItemProfile : Profile
    {
        public SellableItemProfile()
        {
            CreateMap<SellableItemModel, SellableItem>();
            CreateMap<SellableItem, SellableItemModel>();
            CreateMap<IEnumerable<SellableItem>, SellableItemModelCollection>()
                .ConvertUsing(s => new SellableItemModelCollection(s.Select(i =>
                    new SellableItemModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Price = i.Price,
                        Quantity = i.Quantity
                    }).ToList()));
        }
    }
}