using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Infra.Context;
using BackendApi.Infra.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Infra.Repositorio
{
    public class DefeitoRepositorio : RepositorioGenerico<Defeito>, IDefeitoRepositorio
    {
        private readonly MeuContext _contexto;
        public DefeitoRepositorio(MeuContext dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }

        public List<Defeito> BuscarTodosPorDescricao(string descricao)
        {
            var resultado = new List<Defeito>();
            if (string.IsNullOrEmpty(descricao))
            {
                resultado = _contexto.Defeito.AsNoTracking().ToList();
            }
            else
            {
                resultado = _contexto.Defeito.AsNoTracking().Where(b => b.Descricao.Contains(descricao)).ToList();
            }
            return resultado;
        }
    }
}
