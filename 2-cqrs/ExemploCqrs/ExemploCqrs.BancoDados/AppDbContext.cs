using ExemploCqrs.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ExemploCqrs.BancoDados
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; protected set; }
        public DbSet<Pedido> Pedidos { get; protected set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().ToTable(nameof(Cliente));

            modelBuilder.Entity<Pedido>().ToTable(nameof(Pedido));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
