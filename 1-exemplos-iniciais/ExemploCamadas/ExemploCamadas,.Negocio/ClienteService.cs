using ExemploCamadas.Dados;
using ExemploCamadas.Modelo;

namespace ExemploCamadas.Negocio
{
    public class ClienteService : IService<Cliente>
    {

        public void Salvar(Cliente model)
        {
            var repositorio = new ClienteRepositorio();
            repositorio.Salvar(model);
        }

        public void Atualizar(Cliente model)
        {
            var repositorio = new ClienteRepositorio();
            repositorio.Atualizar(model);
        }

        public Cliente Ler(int id)
        {
            var repositorio = new ClienteRepositorio();
            var cliente = repositorio.Ler(id);
            return cliente;
        }

        public List<Cliente> Listar()
        {
            var repositorio = new ClienteRepositorio();
            var clientes = repositorio.Listar();
            return clientes;
        }

        public void Excluir(int id)
        {
            var repositorio = new ClienteRepositorio();
            repositorio.Excluir(id);
        }
    }
}
