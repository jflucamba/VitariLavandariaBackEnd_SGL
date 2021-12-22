using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Data.Context;
using VL.Manager.Interfaces.Repository;

namespace VL.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly VlContext context;

        public UsuarioRepository(VlContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAsync()
        {
            return await context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario> GetAsync(string login)
        {
            return await context.Usuarios
                .Include(p => p.Cargos)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Login == login);
        }

        public async Task<Usuario> InsertAsync(Usuario usuario)
        {
            await InsertUsuarioFuncaoAsync(usuario);
            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }

        private async Task InsertUsuarioFuncaoAsync(Usuario usuario)
        {
            var funcoesConsultas = new List<Cargo>();
            foreach (var funcao in usuario.Cargos)
            {
                var funcaoConsultada = await context.Cargos.FindAsync(funcao.Id);
                funcoesConsultas.Add(funcaoConsultada);
            }
            usuario.Cargos = funcoesConsultas;
        }

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            var usuarioConsultado = await context.Usuarios.FindAsync(usuario.Login);
            if (usuarioConsultado == null)
            {
                return null;
            }
            context.Entry(usuarioConsultado).CurrentValues.SetValues(usuario);
            await context.SaveChangesAsync();
            return usuarioConsultado;
        }
    }
}