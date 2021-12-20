using AutoMapper;
using VL.Core.Domain;
using VL.Core.Shared.ModelView;

namespace VL.Manager.Mappings.EstadoPedidoMap
{
    public class AlterarEstadoPedidoMappingProfile : Profile
    {
        public AlterarEstadoPedidoMappingProfile()
        {
            CreateMap<AlterarEstadoPedido, EstadoPedido>();
        }
    }
}