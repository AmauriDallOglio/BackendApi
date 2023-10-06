using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Validador;

namespace BackendApi.Dominio.Entidade
{
    public class AtivoLocal : AuditableEntity<Guid>, ITenantObrigatorio
    {
        public Guid Id { get; set; }  
        public Guid Id_Tenant { get; set; }  
        public string Referencia { get; set; } = string.Empty;  
        public string Area { get; set; } = string.Empty; 
        public string Setor { get; set; } = string.Empty; 
        public string Descricao { get; set; } = string.Empty; 
        public bool Inativo { get; set; }

  
        public AtivoLocal DadosDoIncluir()
        {
            this.Inativo = false;
            return this;
        }

        public ResultadoOperacao ValidaDados(AtivoLocal entidade)
        {
            //Valida os campos obrigatorio do mapeamento
            var validador = new AtivoLocalValidador().Validar(entidade);
            return validador;
        }

    }
}
