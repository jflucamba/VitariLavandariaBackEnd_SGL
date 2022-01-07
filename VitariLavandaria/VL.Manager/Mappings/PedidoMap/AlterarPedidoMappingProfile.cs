using AutoMapper;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Pedido;

namespace VL.Manager.Mappings.PedidoMap
{
    public class AlterarPedidoMappingProfile : Profile
    {
        public AlterarPedidoMappingProfile()
        {
            CreateMap<AlterarPedido, Pedido>();
        }
    }
}