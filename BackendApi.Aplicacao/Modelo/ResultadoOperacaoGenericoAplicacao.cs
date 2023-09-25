

using BackendApi.Dominio.Modelo;

namespace BackendApi.Aplicacao.Modelo
{
    public class ResultadoOperacaoGenericoAplicacao<T>
    {
        public ResultadoOperacaoGenericoAplicacao()
        {
            ResultadoOperacao = new ResultadoOperacao<T>(default(T))
            {
      
                Sucesso = true,
                Mensagem = ""
            };
        }

        public ResultadoOperacao<T> ResultadoOperacao { get; set; }
    }
}
