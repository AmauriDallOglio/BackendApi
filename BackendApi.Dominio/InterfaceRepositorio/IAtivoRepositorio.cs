using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.Modelo;

namespace BackendApi.Dominio.InterfaceRepositorio
{
    public interface IAtivoRepositorio : IRepositorioGenerico<Ativo>
    {
        List<Ativo> BuscarTodosPorDescricao(string descricao);

        //Ativo ConsultarAtivosDeUmAtivoLocal(Guid ativoLocalId);

    }
}
