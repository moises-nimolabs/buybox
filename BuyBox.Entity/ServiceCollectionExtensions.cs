using BuyBox.Data.Repositories;
using BuyBox.Data.Repositories.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace BuyBox.Data
{
    public static class ServiceCollectionExtensions
    {
        // ReSharper disable once UnusedMethodReturnValue.Global
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            services.AddTransient<ISessionRepository, SessionRepository>();
            services.AddTransient<ILedgerRepository, LedgerRepository>();
            services.AddTransient<ISellableItemRepository, SellableItemRepository>();
            services.AddScoped<BuyBoxDbContext>();
            return services;
        }
    }
}