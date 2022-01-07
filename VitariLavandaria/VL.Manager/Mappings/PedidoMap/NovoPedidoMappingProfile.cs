using AutoMapper;
using System;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Pedido;

namespace VL.Manager.Mappings.PedidoMap
{
    public class NovoPedidoMappingProfile : Profile
    {
        public NovoPedidoMappingProfile()
        {
            CreateMap<NovoPedido, Pedido>()
                .ForMember(d => d.DataAbertura, o => o.MapFrom(x => DateTime.Now));
        }
    }
}