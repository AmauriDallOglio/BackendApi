using MediatR;
using Newtonsoft.Json;

namespace BackendApi.Aplicacao.Aplicacao.Auditoria
{
    public class AuditoriaInserirRequest : IRequest<AuditoriaInserirResponse>
    {
        public Guid IdTenant { get; set; }
        public Guid IdRegistro { get; set; }
        public string NomeTabela { get; set; }
        public int ModoCrud { get; set; }
        public string Json { get; set; } = string.Empty;

        // O atributo genérico Json
       /// public T Dados { get; set; }
        //public string SerializarDados()
        //{
        //    return JsonConvert.SerializeObject(Dados);
        //}

        //public void DeserializarDados(string json)
        //{
        //    Dados = JsonConvert.DeserializeObject<T>(json);
        //}
    }
}
