using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Tenant
{
    public class TenantAlterarRequest : IRequest<TenantAlterarResponse>
    {
        public Guid Id { get; set; }
        public Guid? Id_Imagem { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Inativo { get; set; }
    }
}
