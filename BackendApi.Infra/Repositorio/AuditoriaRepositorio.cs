using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Infra.Context;
using BackendApi.Infra.Modelo;

namespace BackendApi.Infra.Repositorio
{
    public class AuditoriaRepositorio : RepositorioGenerico<Auditoria>, IAuditoriaRepositorio
    {
        private readonly MeuContext _contexto;
        public AuditoriaRepositorio(MeuContext dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }
    }
}
