using AutoMapper;
using VL.Core.Domain;
using VL.Core.Shared.ModelView;

namespace VL.Manager.Mappings
{
    public class AlterarCargoMappingProfile : Profile
    {
        public AlterarCargoMappingProfile()
        {
            CreateMap<AlterarCargo, Cargo>();
        }
    }
}