using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Pedido;

namespace VL.Manager.Interfaces.Manager
{
    public interface IPedidoManager
    {
        Task DeletePedidoAsync(int id);

        Task<Pedido> GetPedidoAsync(int id);

        Task<IEnumerable<Pedido>> GetPedidosAsync();

        Task<Pedido> InsertPedidoAsync(NovoPedido novoPedido);

        Task<Pedido> UpdatePedidoAsync(AlterarPedido pedido);
    }
}