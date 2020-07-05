using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BuyBox.Data.Entities;
using BuyBox.Domain.Models;

namespace BuyBox.Domain.Mapping.Profiles
{
    public class TokenProfile : Profile
    {
        public TokenProfile()
        {
            CreateMap<Token, TokenModel>();
            CreateMap<TokenModel, Token>();
            CreateMap<IEnumerable<Token>, TokenModelCollection>()
                .ConvertUsing(s => new TokenModelCollection(s.Select(i =>
                    new TokenModel
                    {
                        Id = i.Id,
                        Value = i.Value
                    }).ToList()));
            CreateMap<IEnumerable<ExchangeToken>, TokenModelCollection>()
                .ConvertUsing(s => new TokenModelCollection(s.Select(i =>
                    new TokenModel
                    {
                        Id = i.Id,
                        Value = i.Value
                    }).ToList()));
        }
    }
}