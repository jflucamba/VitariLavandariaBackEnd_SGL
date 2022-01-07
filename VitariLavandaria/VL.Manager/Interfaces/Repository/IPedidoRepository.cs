using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;

namespace VL.Manager.Interfaces.Repository
{
    public interface IPedidoRepository
    {
        Task<Pedido> DeletePedidoAsync(int id);
        Task<Pedido> GetPedidoAsync(int id);
        Task<IEnumerable<Pedido>> GetPedidosAsync();
        Task<Pedido> InsertPedidoAsync(Pedido novoPedido);
        Task<Pedido> UpdatePedidoAsync(Pedido pedido);
    }
}