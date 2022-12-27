using MediatR;

namespace ExemploCqrs.Aplicacao.Recursos.Pedidos.AdicionarPedido
{
    public class AdicionarPedidoCommand : IRequest
    {
        public int CustomerId { get; set; }
        public decimal Price { get; set; }
    }
}
