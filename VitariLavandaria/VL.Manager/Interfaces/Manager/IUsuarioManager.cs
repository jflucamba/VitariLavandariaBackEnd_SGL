using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Usuario;

namespace VL.Manager.Interfaces.Manager
{
    public interface IUsuarioManager
    {

        Task<IEnumerable<UsuarioView>> GetAsync();

        Task<UsuarioView> GetAsync(string login);

        Task<UsuarioView> InsertAsync(NovoUsuario usuario);

        Task<UsuarioView> UpdateMedicoAsync(Usuario usuario);

        Task<UsuarioLogado> ValidaUsuarioEGeraTokenAsync(Usuario usuario);

    }
}