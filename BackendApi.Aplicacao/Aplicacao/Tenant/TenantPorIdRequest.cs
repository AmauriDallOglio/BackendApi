using BackendApi.Dominio.Modelo;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Tenant
{
    public class TenantPorIdRequest : IRequest<TenantPorIdResponse>
    {
        public Guid Id { get; set; }
    }
}
