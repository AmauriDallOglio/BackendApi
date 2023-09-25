using BackendApi.Dominio.Modelo;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Tenant
{
    public class TenantListarTodosRequest : IRequest<RetornoPaginadoGenerico<TenantListarTodosResponse>>
    {
        public string? Descricao { get; set; }
    }
}
 