using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;

namespace VL.Manager.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAsync();

        Task<Usuario> GetAsync(string login);

        Task<Usuario> InsertAsync(Usuario usuario);

        Task<Usuario> UpdateAsync(Usuario usuario);
    }
}