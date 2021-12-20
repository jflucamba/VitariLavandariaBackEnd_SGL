using Microsoft.Extensions.DependencyInjection;
using VL.Data.Repository;
using VL.Manager.Implementation;
using VL.Manager.Interfaces;
using VL.Manager.Interfaces.Manager;
using VL.Manager.Interfaces.Repository;

namespace VL.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<ICargoManager, CargoManager>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoManager, ProdutoManager>();
            
        }
    }
}