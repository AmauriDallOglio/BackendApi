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
                resultado = _contexto.Ativo.Include(x => x.AtivoLocal)
                                           .Include(x => x.Tenant)
                                           .Include(x => x.AtivoTipo)
                                           .ToList();
            }
            else
            {
                resultado = _contexto.Ativo.Include(x => x.AtivoLocal)
                                           .Include(x => x.Tenant)
                                           .Include(x => x.AtivoTipo)
                                           .Where(b => b.Descricao.Contains(descricao))
                                           .ToList();
            }
            return resultado;
        }

        //public Ativo ConsultarAtivosDeUmAtivoLocal(Guid ativoLocalId)
        //{
        //    Ativo ativoLocal = _contexto.Ativo.Include(x => x.Tenant).Where(al => al.Id == ativoLocalId).FirstOrDefault();

        //    return ativoLocal;

        //}

    }
}
