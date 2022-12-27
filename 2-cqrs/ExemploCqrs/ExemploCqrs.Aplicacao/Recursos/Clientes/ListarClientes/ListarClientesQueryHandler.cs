using ExemploCqrs.BancoDados;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExemploCqrs.Aplicacao.Recursos.Clientes.ListarClientes
{
    public class ListarClientesQueryHandler : IRequestHandler<ListarClientesQuery, IEnumerable<ClienteModel>>
    {
        private readonly AppDbContext _dbContext;

        public ListarClientesQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ClienteModel>> Handle(ListarClientesQuery request, CancellationToken cancellationToken)
        {
            var customers = await _dbContext.Clientes.ToListAsync();

            return customers.Select(x => new ClienteModel
            {
                Id = x.ClienteId,
                Name = x.Nome,
                Email = x.Email,
            });
        }
    }
}
