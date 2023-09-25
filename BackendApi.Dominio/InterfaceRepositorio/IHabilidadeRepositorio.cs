using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.Modelo;

namespace BackendApi.Dominio.InterfaceRepositorio
{
    public interface IHabilidadeRepositorio : IRepositorioGenerico<Habilidade>
    {
        List<Habilidade> BuscarTodosPorDescricao(string descricao);
    }
}
