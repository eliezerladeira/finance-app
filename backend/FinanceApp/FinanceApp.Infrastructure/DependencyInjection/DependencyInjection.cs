using Microsoft.Extensions.DependencyInjection;
using FinanceApp.Domain.Repositories;
using FinanceApp.Infrastructure.Repositories;

namespace FinanceApp.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IPurchaseGroupRepository, PurchaseGroupRepository>();

            // Se tiver outros, adiciona aqui

            return services;
        }
    }
}