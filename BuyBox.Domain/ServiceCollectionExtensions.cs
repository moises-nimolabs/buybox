using AutoMapper;
using BuyBox.Domain.Mapping.Profiles;
using BuyBox.Domain.Services;
using BuyBox.Domain.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace BuyBox.Domain
{
    public static class ServiceCollectionExtensions
    {
        // ReSharper disable once UnusedMethodReturnValue.Global
        public static IServiceCollection AddDomainLayer(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new SessionProfile());
                mc.AddProfile(new SellableItemProfile());
                mc.AddProfile(new TokenProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<ISellableItemService, SellableItemService>();
            return services;
        }
    }
}