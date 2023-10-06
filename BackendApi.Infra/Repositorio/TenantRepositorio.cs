using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Infra.Context;
using BackendApi.Infra.Modelo;

namespace BackendApi.Infra.Repositorio
{
    public class TenantRepositorio : RepositorioGenerico<Tenant>, ITenantRepositorio
    {
        private readonly MeuContext _contexto;
        //private readonly Global _global;
        public TenantRepositorio(MeuContext dbContext ) : base(dbContext)
        {
            _contexto = dbContext;
            //_global = global;
        }
        public List<Tenant> BuscarTodosPorDescricao(string descricao)
        {
            var resultado = new List<Tenant>();
            if (string.IsNullOrEmpty(descricao)) 
            {
                resultado = _contexto.Tenant.ToList();
            }
            else
            {
                resultado = _contexto.Tenant.Where(b => b.Descricao.Contains(descricao)).ToList();
            }
            return resultado;
        }
    }
}