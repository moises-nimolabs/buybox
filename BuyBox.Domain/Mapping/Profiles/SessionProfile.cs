using AutoMapper;
using BuyBox.Data.Entities;
using BuyBox.Domain.Models;

namespace BuyBox.Domain.Mapping.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<Session, SessionModel>();
            CreateMap<SessionModel, Session>();
        }
    }
}