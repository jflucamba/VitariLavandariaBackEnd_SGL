using AutoMapper;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Produto;

namespace VL.Manager.Mappings.ProdutoMap
{
    public class AlterarProdutoMappingProfile : Profile
    {
        public AlterarProdutoMappingProfile()
        {
            CreateMap<AlterarProduto, Produto>();
        }
    }
}