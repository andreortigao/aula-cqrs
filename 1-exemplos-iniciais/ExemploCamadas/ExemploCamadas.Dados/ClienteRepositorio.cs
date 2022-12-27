using Dapper;
using ExemploCamadas.Modelo;
using Microsoft.Data.SqlClient;

namespace ExemploCamadas.Dados
{
    public class ClienteRepositorio : IRepositorio<Cliente>
    {
        private const string _connString = @"Server=localhost\SQLEXPRESS;Initial Catalog=aula;Integrated Security=SSPI;TrustServerCertificate=True";

        public void Atualizar(Cliente cliente)
        {
            using (var sqlConnection = new SqlConnection(_connString))
            {
                sqlConnection.Execute("UPDATE [dbo].[Cliente] SET [Nome] = @Nome ,[Email] = @Email, [DataNascimento] = @DataNascimento WHERE ClienteId = @ClienteId", cliente);
            }
        }

        public void Excluir(int id)
        {
            using (var sqlConnection = new SqlConnection(_connString))
            {
                sqlConnection.Execute("DELETE [dbo].[Cliente] WHERE ClienteId = @id", id);
            }
        }

        public Cliente Ler(int id)
        {
            using (var sqlConnection = new SqlConnection(_connString))
            {
                return sqlConnection.QueryFirstOrDefault<Cliente>("SELECT ClienteId, Nome, Email, DataNascimento FROM Cliente WHERE ClienteId = @Id", id);
            }
        }

        public List<Cliente> Listar()
        {
            using (var sqlConnection = new SqlConnection(_connString))
            {
                return sqlConnection.Query<Cliente>("SELECT ClienteId, Nome, Email, DataNascimento FROM Cliente").ToList();
            }
        }

        public void Salvar(Cliente cliente)
        {
            using (var sqlConnection = new SqlConnection(_connString))
            {
                cliente.ClienteId = sqlConnection.ExecuteScalar<int>("INSERT INTO [dbo].[Cliente] ([Nome], [Email], [DataNascimento]) VALUES (@Nome, @Email, @DataNascimento); SELECT @@IDENTITY", cliente);
            }
        }
    }
}
