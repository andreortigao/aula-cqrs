namespace ExemploCamadas.Modelo
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public decimal Preco { get; set; }
        public bool Pago { get; set; }
        public DateTime DataPedido { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
