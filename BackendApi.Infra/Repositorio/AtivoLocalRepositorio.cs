using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Infra.Context;
using BackendApi.Infra.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Infra.Repositorio
{
    public class AtivoLocalRepositorio : RepositorioGenerico<AtivoLocal>, IAtivoLocalRepositorio
    {
        private readonly MeuContext _contexto;
        public AtivoLocalRepositorio(MeuContext dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }

        public List<AtivoLocal> BuscarTodosPorDescricao(string descricao)
        {
            var resultado = new List<AtivoLocal>();
            if (string.IsNullOrEmpty(descricao))
            {
                resultado = _contexto.AtivoLocal.AsNoTracking().ToList();
            }
            else
            {
                resultado = _contexto.AtivoLocal.AsNoTracking().Where(b => b.Descricao.Contains(descricao)).ToList();
            }
            return resultado;
        }
    }
}
