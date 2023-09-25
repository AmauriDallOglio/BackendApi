using BackendApi.Dominio.Modelo;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Tenant
{
    public class TenantListarTodos 
    {
        public class Request : IRequest<RetornoPaginadoGenerico<Response>>
        {
            public string? Descricao { get; set; }
        }

        public class Response : Dominio.Entidade.Tenant
        {

        }
    }
}
 