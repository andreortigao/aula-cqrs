using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCqrs.Aplicacao.Recursos.Pedidos.ListarPedidos
{
    public class PedidoModel
    {
        public int Id { get; internal set; }
        public decimal Price { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
    }
}
