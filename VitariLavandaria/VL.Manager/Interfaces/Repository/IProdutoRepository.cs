using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Produto;

namespace VL.Manager.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        Task DeleteProdutoAsync(int id);
        Task<Produto> GetProdutoAsync(int id);
        Task<IEnumerable<Produto>> GetProdutosAsync();
        Task<Produto> InsertProdutoAsync(Produto novoProduto);
        Task<Produto> UpdateProdutoAsync(AlterarProduto produto);
    }
}