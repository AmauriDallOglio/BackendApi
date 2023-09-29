using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Infra.Context;
using BackendApi.Infra.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Infra.Repositorio
{
    public class TenantRepositorio : RepositorioGenerico<Tenant>, ITenantRepositorio
    {
        private readonly MeuContext _contexto;
        public TenantRepositorio(MeuContext dbContext) : base(dbContext)
        {
            _contexto = dbContext;
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