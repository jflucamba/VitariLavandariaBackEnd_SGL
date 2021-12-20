using Microsoft.Extensions.DependencyInjection;
using VL.Manager.Mappings;
using VL.Manager.Mappings.ProdutoMap;

namespace VL.WebApi.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(NovoCargoMappingProfile),
                typeof(AlterarCargoMappingProfile),
                typeof(NovoProdutoMappingProfile),
                typeof(AlterarProdutoMappingProfile));
        }
    }
}