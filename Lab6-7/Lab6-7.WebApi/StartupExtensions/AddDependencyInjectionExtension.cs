using Lab6_7.BLL.Interfaces.Contractor;
using Lab6_7.BLL.Interfaces.Product;
using Lab6_7.BLL.Services.Contractor;
using Lab6_7.BLL.Services.Product;
using Lab6_7.DataAccess.Repositories.Interfaces.Contractor;
using Lab6_7.DataAccess.Repositories.Interfaces.Product;
using Lab6_7.DataAccess.Repositories.Realizations.Contractor;
using Lab6_7.DataAccess.Repositories.Realizations.Product;
using Microsoft.Extensions.DependencyInjection;

namespace Lab6_7.WebApi.StartupExtensions
{
    public static class AddDependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IContractorRepo, ContractorRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IContractorService, ContractorService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
