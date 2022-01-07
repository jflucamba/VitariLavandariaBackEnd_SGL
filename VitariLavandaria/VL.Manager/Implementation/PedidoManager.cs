using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Pedido;
using VL.Manager.Interfaces.Manager;
using VL.Manager.Interfaces.Repository;

namespace VL.Manager.Implementation
{
    public class PedidoManager : IPedidoManager
    {
        private readonly IPedidoRepository repository;
        private readonly IMapper mapper;

        public PedidoManager(IPedidoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task DeletePedidoAsync(int id)
        {
            await repository.DeletePedidoAsync(id);
        }

        public async Task<Pedido> GetPedidoAsync(int id)
        {
            return await repository.GetPedidoAsync(id);
        }

        public async Task<IEnumerable<Pedido>> GetPedidosAsync()
        {
            return await repository.GetPedidosAsync();
        }

        public async Task<Pedido> InsertPedidoAsync(NovoPedido novoPedido)
        {
            var pedido = mapper.Map<Pedido>(novoPedido);
            return await repository.InsertPedidoAsync(pedido);
        }

        public async Task<Pedido> UpdatePedidoAsync(AlterarPedido alterarPedido)
        {
            var pedido = mapper.Map<Pedido>(alterarPedido);
            return await repository.UpdatePedidoAsync(alterarPedido);
        }
    }
}