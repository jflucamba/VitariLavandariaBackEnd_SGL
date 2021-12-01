using Microsoft.EntityFrameworkCore;
using VL.Core.Domain;

namespace VL.Data.Context
{
    public class VlContext : DbContext
    {
        public DbSet<Cargo> Cargos { get; set; }

        public VlContext(DbContextOptions options) : base(options)
        {
        }
    }
}