using ExemploCqrs.BancoDados;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCqrs.Aplicacao.Recursos.Pedidos.ListarPedidos
{
    public class ListarPedidoQueryHandler : IRequestHandler<ListarPedidosQuery, IEnumerable<PedidoModel>>
    {
        private readonly AppDbContext _appDbContext;

        public ListarPedidoQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<PedidoModel>> Handle(ListarPedidosQuery request, CancellationToken cancellationToken)
        {
            var query = _appDbContext.Pedidos.AsQueryable();

            if(request.PrecoMinimo is object)
            {
                query = query.Where(x => x.Preco > request.PrecoMinimo);
            }

            if(request.PrecoMaximo is object)
            {
                query = query.Where(x => x.Preco < request.PrecoMaximo);
            }

            var pedidos = await query.ToListAsync();

            return pedidos.Select(x => new PedidoModel
            {
                Id = x.PedidoId,
                Price = x.Preco,
                CreatedAt = x.DataPedido
            });
        }
    }
}
