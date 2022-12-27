using ExemploCamadas.Modelo;
using Microsoft.EntityFrameworkCore;

namespace ExemploCamadas.Dados
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; protected set; }
        public DbSet<Pedido> Pedido { get; protected set; }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=aula;Integrated Security=SSPI;TrustServerCertificate=True");
        }
    }
}
