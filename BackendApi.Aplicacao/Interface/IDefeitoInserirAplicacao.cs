using BackendApi.Aplicacao.Aplicacao.Defeito;
using BackendApi.Dominio.Modelo;

namespace BackendApi.Aplicacao.Interface
{
    internal interface IDefeitoInserirAplicacao
    {
        public ResultadoOperacao<DefeitoIncluir.Response> CriarResultadoOperacao();
        ResultadoOperacao<Dominio.Entidade.Defeito> ValidaMapeamento(Dominio.Entidade.Defeito entidade);
    }
}
