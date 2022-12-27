namespace ExemploCqrs.Dominio
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
