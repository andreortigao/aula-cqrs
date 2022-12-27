namespace ExemploCqrs.Dominio
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataPedido { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}
