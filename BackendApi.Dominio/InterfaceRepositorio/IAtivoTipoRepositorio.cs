using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.Modelo;

namespace BackendApi.Dominio.InterfaceRepositorio
{
    public interface IAtivoTipoRepositorio : IRepositorioGenerico<AtivoTipo>
    {
        List<AtivoTipo> BuscarTodosPorDescricao(string descricao);
    }
}
