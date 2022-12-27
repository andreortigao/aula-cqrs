using ExemploHexagonal.AdapterOutRepository.postgreSql.repositories;
using ExemploHexagonal.Domain.Clientes.PortasSaida;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploHexagonal.AdapterOutRepository
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IClienteRepositorio, ProductRepository>();

            return serviceCollection;
        }
    }
}
