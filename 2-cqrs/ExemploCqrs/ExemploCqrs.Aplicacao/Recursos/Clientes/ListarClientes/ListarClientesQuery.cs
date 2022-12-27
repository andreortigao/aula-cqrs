using MediatR;

namespace ExemploCqrs.Aplicacao.Recursos.Clientes.ListarClientes
{
    public class ListarClientesQuery : IRequest<IEnumerable<ClienteModel>>
    {
    }
}
