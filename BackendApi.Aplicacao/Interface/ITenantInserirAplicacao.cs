using BackendApi.Aplicacao.Aplicacao.Tenant;
using BackendApi.Dominio.Modelo;

namespace BackendApi.Aplicacao.Interface
{
    internal interface ITenantInserirAplicacao
    {
        public ResultadoOperacao<TenantInserirResponse> CriarResultadoOperacao();
        ResultadoOperacao<Dominio.Entidade.Tenant> ValidaMapeamento(Dominio.Entidade.Tenant entidade);

        public string JsonConvertSerializeObject(TenantInserirResponse dto);
    }
}