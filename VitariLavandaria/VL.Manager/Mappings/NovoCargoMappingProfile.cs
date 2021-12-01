using AutoMapper;
using VL.Core.Domain;
using VL.Core.Shared.ModelView;

namespace VL.Manager.Mappings
{
    public class NovoCargoMappingProfile : Profile
    {
        public NovoCargoMappingProfile()
        {
            CreateMap<NovoCargo, Cargo>();
        }
    }
}