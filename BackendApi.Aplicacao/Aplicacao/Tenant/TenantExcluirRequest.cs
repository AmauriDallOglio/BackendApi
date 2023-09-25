using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Tenant
{
    public class TenantExcluirRequest : IRequest<TenantExcluirResponse>
    {
        public Guid Id { get; set; }
    }
}
