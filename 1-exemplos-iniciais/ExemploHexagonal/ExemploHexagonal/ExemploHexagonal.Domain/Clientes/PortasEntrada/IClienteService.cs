using ExemploHexagonal.Domain.Clientes.Modelos;

namespace ExemploHexagonal.Domain.Clientes.PortasEntrada
{
    public interface IClienteService
    {
        Cliente Ler(int id);
    }
}
