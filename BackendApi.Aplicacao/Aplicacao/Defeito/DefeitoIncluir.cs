using BackendApi.Dominio.Modelo;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Defeito
{
    public class DefeitoIncluir
    {
        public class Request : IRequest<ResultadoOperacao<DefeitoIncluirResponse>>
        {
            //public Guid Id { get; set; }
            public Guid Id_Tenant { get; set; }
            public string Referencia { get; set; } = string.Empty;
            public string Descricao { get; set; } = string.Empty;
            public bool Inativo { get; set; }
            public byte TipoDefeito { get; set; }

        }

        public class DefeitoIncluirResponse
        {
            public Guid Id { get; set; }
            public Guid? Id_Imagem { get; set; }
            public Guid Id_Tenant { get; set; }
            public string Referencia { get; set; } = string.Empty;
            public string Descricao { get; set; } = string.Empty;
            public bool Inativo { get; set; }
        }
    }

    

}
