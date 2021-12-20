using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Produto;
using VL.Manager.Interfaces.Manager;
using VL.Manager.Interfaces.Repository;

namespace VL.Manager.Implementation
{
    public class ProdutoManager : IProdutoManager
    {
        private readonly IProdutoRepository produto;
        private readonly IMapper mapper;

        public ProdutoManager(IProdutoRepository produto, IMapper mapper)
        {
            this.produto = produto;
            this.mapper = mapper;
        }

        public async Task DeleteProdutoAsync(int id)
        {
            await produto.DeleteProdutoAsync(id);
        }

        public async Task<Produto> GetProdutoAsync(int id)
        {
            return await produto.GetProdutoAsync(id);
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await produto.GetProdutosAsync();
        }

        public async Task<Produto> InsertProdutoAsync(NovoProduto novoProduto)
        {
            var inserirProduto = mapper.Map<Produto>(novoProduto);
            return await produto.InsertProdutoAsync(inserirProduto);
        }

        public Task<Produto> UpdateProdutoAsync(AlterarProduto produto)
        {
            throw new NotImplementedException();
        }
    }
}
