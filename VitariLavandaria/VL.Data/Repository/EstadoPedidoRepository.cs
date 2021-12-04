using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView;
using VL.Data.Context;
using VL.Manager.Interfaces;

namespace VL.Data.Repository
{
    public class EstadoPedidoRepository : IEstadoPedidoRepository
    {
        private readonly VlContext context;
        //private readonly IMapper mapper;

        public EstadoPedidoRepository(VlContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<EstadoPedido>> GetEstadoPedidosAsync()
        {
            return await context.EstadoPedidos.AsNoTracking().ToListAsync();
        }

        public async Task<EstadoPedido> GetEstadoPedidoAsync(int id)
        {
            return await context.EstadoPedidos.FindAsync(id);
        }

        //Insert
        public async Task<EstadoPedido> InsertEstadoPedidoAsync(EstadoPedido novoPedido)
        {
            await context.EstadoPedidos.AddAsync(novoPedido);
            await context.SaveChangesAsync();
            return novoPedido;
        }

        //Update
        public async Task<EstadoPedido> UpdateEstadoPedidoAsync(AlterarEstadoPedido pedido)
        {
            var pedidoConsultado = await context.EstadoPedidos.FindAsync(pedido.Id);

            if (pedidoConsultado == null)
            {
                return null;
            }

            context.Entry(pedidoConsultado).CurrentValues.SetValues(pedido);

            await context.SaveChangesAsync();
            return pedidoConsultado;
        }

        //Delete
        public async Task DeleteEstadoPedidoAsync(int id)
        {
            var pedidoConsultado = await context.EstadoPedidos.FindAsync(id);
            context.EstadoPedidos.Remove(pedidoConsultado);
            await context.SaveChangesAsync();
        }
    }
}