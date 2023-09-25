using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Infra.Context;
using BackendApi.Infra.Modelo;

namespace BackendApi.Infra.Repositorio
{
    public class CheckListTipoRepositorio : RepositorioGenerico<CheckListTipo>, ICheckListTipoRepositorio
    {
        private readonly MeuContext _contexto;
        public CheckListTipoRepositorio(MeuContext dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }
    }
}
