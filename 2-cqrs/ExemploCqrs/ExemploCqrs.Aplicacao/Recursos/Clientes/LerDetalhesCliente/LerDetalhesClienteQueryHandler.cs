using ExemploCqrs.Aplicacao.Excecoes;
using ExemploCqrs.BancoDados;
using ExemploCqrs.Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExemploCqrs.Aplicacao.Recursos.Clientes.LerDetalhesCliente
{
    public class LerDetalhesClienteQueryHandler : IRequestHandler<LerDetalhesClienteQuery, ClienteDetalhes>
    {
        private readonly AppDbContext _dbContext;

        public LerDetalhesClienteQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ClienteDetalhes> Handle(LerDetalhesClienteQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _dbContext.Clientes
                .Include(x => x.Pedidos)
                .FirstOrDefaultAsync(x => x.ClienteId == request.ClienteId);

            if (cliente == null)
            {
                throw new NotFoundException(nameof(Cliente), request.ClienteId);
            }

            return new ClienteDetalhes()
            {
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Pedidos = cliente.Pedidos.Select(x => new PedidoDetalhes
                {
                    PedidoId = x.PedidoId,
                    Preco = x.Preco,
                    DataPedido = x.DataPedido,
                })
            };
        }
    }
}
