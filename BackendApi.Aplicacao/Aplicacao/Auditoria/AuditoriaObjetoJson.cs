using BackendApi.Aplicacao.Modelo;
using BackendApi.Dominio.Util;

namespace BackendApi.Aplicacao.Aplicacao.Auditoria
{
    public class AuditoriaObjetoJson
    {
        public async Task<AuditoriaInserirRequest> Criar<T>(T obj, Guid idTenante, Guid idRegistroAtual, string nomeTabela, ModoCruds modo)
        {
            SerializacaoJsonAplicacao serializacao = new SerializacaoJsonAplicacao();
            string json = serializacao.RetornaJson(obj);
            AuditoriaInserirRequest auditoria = new AuditoriaInserirRequest
            {
                IdTenant = idTenante,
                IdRegistro = idRegistroAtual,
                NomeTabela = nomeTabela,
                ModoCrud = (short)modo,
                Json = json
            };

            return auditoria;
        }
    }
}
