using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView;
using VL.Manager.Interfaces;

namespace VL.Manager.Implementation
{
    public class EstadoPedidoManager : IEstadoPedidoManager
    {
        private readonly IEstadoPedidoRepository estadoPedido;
        private readonly IMapper mapper;

        public EstadoPedidoManager(IEstadoPedidoRepository estadoPedido, IMapper mapper)
        {
            this.estadoPedido = estadoPedido;
            this.mapper = mapper;
        }

        public async Task DeleteEstadoPedidoAsync(int id)
        {
            await estadoPedido.DeleteEstadoPedidoAsync(id);
        }

        public async Task<EstadoPedido> GetEstadoPedidoAsync(int id)
        {
            return await estadoPedido.GetEstadoPedidoAsync(id);
        }

        public async Task<IEnumerable<EstadoPedido>> GetEstadoPedidosAsync()
        {
            return await estadoPedido.GetEstadoPedidosAsync();
        }

        public async Task<EstadoPedido> InsertEstadoPedidoAsync(NovoEstadoPedido novoPedido)
        {
            var pedido = mapper.Map<EstadoPedido>(novoPedido);
            return await estadoPedido.InsertEstadoPedidoAsync(pedido);
        }

        public async Task<EstadoPedido> UpdateEstadoPedidoAsync(AlterarEstadoPedido alterarPedido)
        {
            var cliente = mapper.Map<EstadoPedido>(alterarPedido);
            return await estadoPedido.UpdateEstadoPedidoAsync(alterarPedido);
        }
    }
}