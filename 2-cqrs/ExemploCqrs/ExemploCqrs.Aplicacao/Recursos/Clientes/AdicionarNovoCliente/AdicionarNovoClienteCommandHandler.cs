using ExemploCqrs.Aplicacao.Eventos.Clientes;
using ExemploCqrs.BancoDados;
using ExemploCqrs.Dominio;
using MediatR;

namespace ExemploCqrs.Aplicacao.Recursos.Clientes.AdicionarNovoCliente
{
    public class AdicionarNovoClienteCommandHandler : IRequestHandler<AdicionarNovoClienteCommand>
    {
        private readonly AppDbContext _dbContext;
        private readonly IPublisher _publisher;

        public AdicionarNovoClienteCommandHandler(AppDbContext dbContext, IPublisher publisher)
        {
            _dbContext = dbContext;
            _publisher = publisher;
        }

        public async Task<Unit> Handle(AdicionarNovoClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente
            {
                Nome = request.Name,
                Email = request.Email
            };

            _dbContext.Clientes.Add(cliente);

            await _dbContext.SaveChangesAsync(cancellationToken);

            await _publisher.Publish(new ClienteCriadoEvent { Cliente = cliente });

            return Unit.Value;
        }
    }
}
