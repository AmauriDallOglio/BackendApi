using BackendApi.Dominio.Modelo;

namespace BackendApi.Aplicacao.Modelo
{
    public interface IInserirGenericoAplicacao<TEntity, TResponse>
    {
       // ResultadoOperacaoGenerico<TResponse> CriarResultadoOperacao();
        ResultadoOperacao<TEntity> ValidaMapeamento(TEntity entidade);
        string JsonConvertSerializeObject(TResponse dto);
    }
}