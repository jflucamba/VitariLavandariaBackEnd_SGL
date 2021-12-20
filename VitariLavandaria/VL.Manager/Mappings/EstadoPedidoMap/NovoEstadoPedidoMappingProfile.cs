using AutoMapper;
using VL.Core.Domain;
using VL.Core.Shared.ModelView;

namespace VL.Manager.Mappings.EstadoPedidoMap
{
    public class NovoEstadoPedidoMappingProfile : Profile
    {
        public NovoEstadoPedidoMappingProfile()
        {
            CreateMap<NovoEstadoPedido, EstadoPedido>();
        }
    }
}