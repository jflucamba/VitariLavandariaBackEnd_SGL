using Microsoft.EntityFrameworkCore;
using VL.Core.Domain;

namespace VL.Data.Context
{
    public class VlContext : DbContext
    {
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<EstadoPedido> EstadoPedidos { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }

        public VlContext(DbContextOptions options) : base(options)
        {
        }
    }
}