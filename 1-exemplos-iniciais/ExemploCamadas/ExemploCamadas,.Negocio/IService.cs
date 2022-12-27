namespace ExemploCamadas.Negocio
{
    public interface IService<T>
    {
        List<T> Listar();
        void Salvar(T model);
        T Ler(int id);
        void Atualizar(T model);
        void Excluir(int id);
    }
}
