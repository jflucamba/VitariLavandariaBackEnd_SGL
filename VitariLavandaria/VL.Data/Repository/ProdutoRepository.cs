using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Produto;
using VL.Data.Context;
using VL.Manager.Interfaces.Repository;

namespace VL.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly VlContext context;

        public ProdutoRepository(VlContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> GetProdutoAsync(int id)
        {
            return await context.Produtos.FindAsync(id);
        }

        //Insert
        public async Task<Produto> InsertProdutoAsync(Produto novoProduto)
        {
            await context.Produtos.AddAsync(novoProduto);
            await context.SaveChangesAsync();
            return novoProduto;
        }

        ////Update
        public async Task<Produto> UpdateProdutoAsync(AlterarProduto produto)
        {
            var produtoConsultado = await context.Produtos.FindAsync(produto.Id);

            if (produtoConsultado == null)
            {
                return null;
            }

            context.Entry(produtoConsultado).CurrentValues.SetValues(produto);

            await context.SaveChangesAsync();
            return produtoConsultado;
        }

        //Delete
        public async Task DeleteProdutoAsync(int id)
        {
            var produtoConsultado = await context.Produtos.FindAsync(id);
            context.Produtos.Remove(produtoConsultado);
            await context.SaveChangesAsync();
        }
    }
}