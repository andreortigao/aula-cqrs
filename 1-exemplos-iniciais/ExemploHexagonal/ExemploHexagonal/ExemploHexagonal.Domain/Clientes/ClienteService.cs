using ExemploHexagonal.Domain.Clientes.Modelos;
using ExemploHexagonal.Domain.Clientes.PortasEntrada;
using ExemploHexagonal.Domain.Clientes.PortasSaida;

namespace ExemploHexagonal.Domain.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IEmailService _emailService;

        public ClienteService(IClienteRepositorio clienteRepositorio, IEmailService emailService)
        {
            _clienteRepositorio = clienteRepositorio;
            _emailService = emailService;
        }

        public void Inserir(Cliente cliente)
        {
            _clienteRepositorio.Inserir(cliente);


        }

        public Cliente Ler(int id)
        {
            var cliente = _clienteRepositorio.Ler(id);

            if (cliente is null)
                throw new Exception($"Cliente {id} não encontrado");

            return cliente;
        }
    }
}
