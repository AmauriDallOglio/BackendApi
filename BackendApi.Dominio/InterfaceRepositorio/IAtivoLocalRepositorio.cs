using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.Modelo;

namespace BackendApi.Dominio.InterfaceRepositorio
{
    public interface IAtivoLocalRepositorio : IRepositorioGenerico<AtivoLocal>
    {
        List<AtivoLocal> BuscarTodosPorDescricao(string descricao);
    }
}
