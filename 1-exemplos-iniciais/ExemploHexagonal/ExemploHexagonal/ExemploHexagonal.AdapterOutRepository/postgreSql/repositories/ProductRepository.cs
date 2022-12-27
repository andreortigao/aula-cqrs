using ExemploHexagonal.AdapterOutRepository.postgreSql.Mapper;
using ExemploHexagonal.Domain.Clientes.Modelos;
using ExemploHexagonal.Domain.Clientes.PortasSaida;

namespace ExemploHexagonal.AdapterOutRepository.postgreSql.repositories
{
    public class ProductRepository : IClienteRepositorio
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public Cliente? Ler(int id)
        {
            var result = _context.Products.Find(id);

            return result.ToDomain();
        }
    }
}
