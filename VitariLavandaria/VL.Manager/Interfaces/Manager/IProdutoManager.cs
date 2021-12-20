using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Produto;

namespace VL.Manager.Interfaces.Manager
{
    public interface IProdutoManager
    {
        Task DeleteProdutoAsync(int id);

        Task<Produto> GetProdutoAsync(int id);

        Task<IEnumerable<Produto>> GetProdutosAsync();

        Task<Produto> InsertProdutoAsync(NovoProduto novoProduto);

        Task<Produto> UpdateProdutoAsync(AlterarProduto produto);
    }
}