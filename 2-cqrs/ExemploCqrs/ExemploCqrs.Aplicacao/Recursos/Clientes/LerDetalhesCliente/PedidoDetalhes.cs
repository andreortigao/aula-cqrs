namespace ExemploCqrs.Aplicacao.Recursos.Clientes.LerDetalhesCliente
{
    public class PedidoDetalhes
    {
        public int PedidoId { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
