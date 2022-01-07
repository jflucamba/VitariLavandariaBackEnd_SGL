using Microsoft.EntityFrameworkCore;
using VL.Core.Domain;
using VL.Data.Configuration;

namespace VL.Data.Context
{
    public class VlContext : DbContext
    {
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<EstadoPedido> EstadoPedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }


        public VlContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                        
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }

    }
}