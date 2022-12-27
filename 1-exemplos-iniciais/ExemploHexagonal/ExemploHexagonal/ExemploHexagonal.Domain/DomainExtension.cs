using ExemploHexagonal.Domain.Clientes;
using ExemploHexagonal.Domain.Clientes.PortasEntrada;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploHexagonal.Domain
{
    public static class DomainExtension
    {
        public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IClienteService, ClienteService>();

            return serviceCollection;
        }
    }
}
