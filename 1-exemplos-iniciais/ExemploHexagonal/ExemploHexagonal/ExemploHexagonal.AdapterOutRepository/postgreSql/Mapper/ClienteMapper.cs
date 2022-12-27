using ExemploHexagonal.AdapterOutRepository.postgreSql.entities;
using ExemploHexagonal.Domain.Clientes.Modelos;

namespace ExemploHexagonal.AdapterOutRepository.postgreSql.Mapper
{
    public static class ClienteMapper
    {
        public static Cliente? ToDomain(this ClienteEntidade? entity)
        {
            if (entity is null)
                return null;

            return new Cliente
            {
                ClienteId = entity.ClienteId,
                Nome = entity.Nome,
                Email = entity.Email,
                DataNascimento = entity.DataNascimento
            };
        }
    }
}
