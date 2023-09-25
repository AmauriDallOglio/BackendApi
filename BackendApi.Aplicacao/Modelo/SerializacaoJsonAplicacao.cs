using Newtonsoft.Json;

namespace BackendApi.Aplicacao.Modelo
{
    public class SerializacaoJsonAplicacao
    {
        public string RetornaJson<T>(T obj)
        {
            string jsonData = JsonConvert.SerializeObject(obj);
            return jsonData;
        }
    }
}
