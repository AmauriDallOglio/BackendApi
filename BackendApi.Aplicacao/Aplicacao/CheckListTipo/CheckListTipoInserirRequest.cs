using BackendApi.Dominio.Modelo;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.CheckListTipo
{
    public class CheckListTipoInserirRequest : IRequest<ResultadoOperacao<CheckListTipoInserirResponse>> 
    {
 
        public Guid Id_Tenant { get; set; }

        public string Referencia { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;
 
    }
     
 
}
