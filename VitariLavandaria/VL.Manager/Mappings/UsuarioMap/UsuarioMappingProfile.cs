using AutoMapper;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Usuario;

namespace VL.Manager.Mappings.UsuarioMap
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<Usuario, UsuarioView>().ReverseMap();
            CreateMap<Usuario, NovoUsuario>().ReverseMap();
            CreateMap<Usuario, UsuarioLogado>().ReverseMap();
            CreateMap<Cargo, CargoView>().ReverseMap();
            CreateMap<Cargo, ReferenciaCargo>().ReverseMap();
        }
    }
}