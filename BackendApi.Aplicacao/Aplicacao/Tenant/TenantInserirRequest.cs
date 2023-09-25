using BackendApi.Dominio.Modelo;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Tenant
{
    public class TenantInserirRequest : IRequest<ResultadoOperacao<TenantInserirResponse>>
    {
        public string Referencia { get; set; }
        public string Descricao { get; set; }

    }
}
