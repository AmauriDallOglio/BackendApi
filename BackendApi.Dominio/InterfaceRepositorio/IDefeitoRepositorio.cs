using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.Modelo;

namespace BackendApi.Dominio.InterfaceRepositorio
{
    public interface IDefeitoRepositorio : IRepositorioGenerico<Defeito>
    {
        List<Defeito> BuscarTodosPorDescricao(string descricao);
    }
}
