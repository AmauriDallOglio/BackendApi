using BackendApi.Dominio.Modelo;

namespace BackendApi.Aplicacao.Interface
{
    internal interface IInserirGenericoAplicacao<T>
    {
        public ResultadoOperacao<T> CriarResultadoOperacao();
        public ResultadoOperacao<T> ValidaMapeamento(T entidade);
        public string JsonConvertSerializeObject(T dto);
    }
}
