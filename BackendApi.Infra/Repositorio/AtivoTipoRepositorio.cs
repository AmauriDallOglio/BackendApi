using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Infra.Context;
using BackendApi.Infra.Modelo;

namespace BackendApi.Infra.Repositorio
{
    public class AtivoTipoRepositorio : RepositorioGenerico<AtivoTipo>, IAtivoTipoRepositorio
    {
        private readonly MeuContext _contexto;
        public AtivoTipoRepositorio(MeuContext dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }

        public List<AtivoTipo> BuscarTodosPorDescricao(string descricao)
        {
            var resultado = new List<AtivoTipo>();
            if (string.IsNullOrEmpty(descricao))
            {
                resultado = _contexto.AtivoTipo.ToList();
            }
            else
            {
                resultado = _contexto.AtivoTipo.Where(b => b.Descricao.Contains(descricao)).ToList();
            }
            return resultado;
        }
    }
}
