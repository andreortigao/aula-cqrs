namespace ExemploCamadas.Dados
{
    public interface IRepositorio<T>
    {
        List<T> Listar();
        void Salvar(T model);
        T Ler(int id);
        void Atualizar(T model);
    }
}
