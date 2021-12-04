using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView;

namespace VL.Manager.Interfaces
{
    public interface IEstadoPedidoRepository
    {
        Task DeleteEstadoPedidoAsync(int id);

        Task<EstadoPedido> GetEstadoPedidoAsync(int id);

        Task<IEnumerable<EstadoPedido>> GetEstadoPedidosAsync();

        Task<EstadoPedido> InsertEstadoPedidoAsync(EstadoPedido novoPedido);

        Task<EstadoPedido> UpdateEstadoPedidoAsync(AlterarEstadoPedido pedido);
    }
}