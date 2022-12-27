namespace ExemploCqrs.Aplicacao.Recursos.Clientes.LerDetalhesCliente
{
    public class ClienteDetalhes
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public IEnumerable<PedidoDetalhes> Pedidos { get; set; }
    }
}
