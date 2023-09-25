using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.Modelo;

namespace BackendApi.Dominio.InterfaceRepositorio
{
    public interface ITenantRepositorio : IRepositorioGenerico<Tenant>
    {
        List<Tenant> BuscarTodosPorDescricao(string descricao);
    }
}
