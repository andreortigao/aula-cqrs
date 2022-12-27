using ExemploCqrs.Aplicacao.Excecoes;
using ExemploCqrs.BancoDados;
using ExemploCqrs.Dominio;
using MediatR;


namespace ExemploCqrs.Aplicacao.Recursos.Pedidos.AdicionarPedido
{
    public sealed class AdicionarPedidoCommandHandler : IRequestHandler<AdicionarPedidoCommand>
    {
        private readonly AppDbContext _dbContext;

        public AdicionarPedidoCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AdicionarPedidoCommand request, CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Clientes.FindAsync(new object[] { request.CustomerId }, cancellationToken: cancellationToken);

            if (customer is null)
                throw new NotFoundException(nameof(Cliente), request.CustomerId);

            var order = new Pedido
            {
                Preco = request.Price,
                ClienteId = request.CustomerId,
                DataPedido = DateTime.UtcNow,
            };

            _dbContext.Pedidos.Add(order);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
