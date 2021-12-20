using AutoMapper;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Produto;

namespace VL.Manager.Mappings.ProdutoMap
{
    public class NovoProdutoMappingProfile : Profile
    {
        public NovoProdutoMappingProfile()
        {
            CreateMap<NovoProduto, Produto>();
        }
    }
}