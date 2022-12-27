namespace ExemploHexagonal.Domain.Clientes.Modelos
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
