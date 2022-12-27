using MediatR;

namespace ExemploCqrs.Aplicacao.Recursos.Clientes.LerDetalhesCliente
{
    public class LerDetalhesClienteQuery : IRequest<ClienteDetalhes>
    {
        public int ClienteId { get; set; }
    }
}
