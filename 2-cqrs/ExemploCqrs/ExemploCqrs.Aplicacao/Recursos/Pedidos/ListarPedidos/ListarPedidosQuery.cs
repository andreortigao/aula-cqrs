using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCqrs.Aplicacao.Recursos.Pedidos.ListarPedidos
{
    public class ListarPedidosQuery : IRequest<IEnumerable<PedidoModel>>
    {
        public decimal? PrecoMinimo { get; set; }
        public decimal? PrecoMaximo { get; set; }
    }
}
