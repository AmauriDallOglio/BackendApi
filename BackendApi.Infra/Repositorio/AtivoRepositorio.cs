using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Infra.Context;
using BackendApi.Infra.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Infra.Repositorio
{
    public class AtivoRepositorio : RepositorioGenerico<Ativo>, IAtivoRepositorio
    {
        private readonly MeuContext _contexto;
        public AtivoRepositorio(MeuContext dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }

        public List<Ativo> BuscarTodosPorDescricao(string descricao)
        {
            var resultado = new List<Ativo>();
            if (string.IsNullOrEmpty(descricao))
            {
                resultado = _contexto.Ativo.AsNoTracking().ToList();
            }
            else
            {
                resultado = _contexto.Ativo.AsNoTracking().Where(b => b.Descricao.Contains(descricao)).ToList();
            }
            return resultado;
        }

    }
}
