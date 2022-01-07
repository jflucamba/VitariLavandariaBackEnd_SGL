using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Pedido;
using VL.Data.Context;
using VL.Manager.Interfaces.Repository;

namespace VL.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly VlContext context;

        public PedidoRepository(VlContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Pedido>> GetPedidosAsync()
        {
            return await context.Pedidos
                //.Include(x => x.Endereco)
                //.Include(x => x.Telefones)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Pedido> GetPedidoAsync(int id)
        {
            return await context.Pedidos
                //.Include(p => p.Endereco)
                //.Include(x => x.Telefones)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        //Insert
        public async Task<Pedido> InsertPedidoAsync(Pedido novoPedido)
        {
            await context.Pedidos.AddAsync(novoPedido);
            await context.SaveChangesAsync();
            return novoPedido;
        }

        public async Task<Pedido> UpdatePedidoAsync(AlterarPedido pedido)
        {
            var pedidoConsultado = await context.Pedidos
                                                 //.Include(p => p.Endereco)
                                                 //.Include(p => p.Telefones)
                                                 .FirstOrDefaultAsync(p => p.Id == pedido.Id);
            if (pedidoConsultado == null)
            {
                return null;
            }
            context.Entry(pedidoConsultado).CurrentValues.SetValues(pedido);
            //pedidoConsultado.Endereco = pedido.Endereco;
            //UpdateClienteTelefones(pedido, pedidoConsultado);
            await context.SaveChangesAsync();
            return pedidoConsultado;
        }

        //Delete
        public async Task DeletePedidoAsync(int id)
        {
            
            var pedidoRemovido = await context.Pedidos.FindAsync(id);
            context.Pedidos.Remove(pedidoRemovido);
            await context.SaveChangesAsync();

        }
    }
}