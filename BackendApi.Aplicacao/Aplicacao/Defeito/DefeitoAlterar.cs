using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Defeito
{
    public class DefeitoAlterar  
    {

        public class Request : IRequest<Response>
        {
            public Guid Id { get; set; }
            //public Guid Id_Tenant { get; set; }
            //public virtual Tenant? Tenant { get; set; }

            public string Referencia { get; set; } = string.Empty;
            public string Descricao { get; set; } = string.Empty;
            //public bool Inativo { get; set; }
            //public int TipoDefeito { get; set; }

        }

        public class Response : Dominio.Entidade.Defeito
        {
 
        }
    }
}
