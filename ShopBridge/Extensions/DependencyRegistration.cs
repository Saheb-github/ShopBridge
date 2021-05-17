using Microsoft.Extensions.DependencyInjection;
using ShopBridge.BussinessProcess.Interfaces;
using ShopBridge.BussinessProcess.Services;
using ShopBridge.DataAccess.Interfaces;
using ShopBridge.DataAccess.Services;
using System.Diagnostics.CodeAnalysis;

namespace ShopBridge.WEB.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DependencyRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            #region Register API Managers
            services.AddTransient<ISBProductManager, SBProductManager>();
            services.AddTransient<ISBUserManager, SBUserManager>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            return services;
        }
    }
}
