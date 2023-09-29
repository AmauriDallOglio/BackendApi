namespace BackendApi.Dominio.Modelo
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        TEntity Inserir(TEntity entidade, bool finalizar);
        TEntity Alterar(TEntity entidade, bool finalizar);
        TEntity Deletar(TEntity entidade);
        TEntity ObterPorId(object id);
        IQueryable<TEntity> ObterTodos();
       // IList<TEntity> ObterTodosPorDescricao(string descricao);
        void Comitar();
    }
}
