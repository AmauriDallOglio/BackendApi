using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.Modelo;
using BackendApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Infra.Modelo
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class
    {
        private readonly MeuContext _dbContext;
        private bool _disposed;

        public RepositorioGenerico(MeuContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Alterar(TEntity entidade, bool finalizar)
        {
            _dbContext.Entry(entidade).State = EntityState.Modified;
            _dbContext.Set<TEntity>().Update(entidade);
            if (finalizar)
            {
                Comitar();
            }
            return entidade;
        }

        public TEntity Deletar(TEntity entidade)
        {
            var reultado = _dbContext.Set<TEntity>().Remove(entidade);
            Comitar();
            return entidade;
        }

        public TEntity Inserir(TEntity entidade, bool finalizar)
        {
            _dbContext.Set<TEntity>().Add(entidade);
            if (finalizar)
            {
                Comitar();
            }
            return entidade;
        }

        public TEntity ObterPorId(object id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> ObterTodos()
        {
            return _dbContext.Set<TEntity>();
        }

        public void Comitar()
        {
            var resultadoCommit = _dbContext.SaveChanges();
       
        }

 
        //public Task Rollback()
        //{
        //    _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        //    return Task.CompletedTask;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            //dispose managed resources
        //            _dbContext.Dispose();
        //        }
        //    }
        //    //dispose unmanaged resources
        //    _disposed = true;
        //}

    }
}
