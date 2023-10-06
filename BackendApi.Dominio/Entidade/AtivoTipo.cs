using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Validador;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApi.Dominio.Entidade
{
    public class AtivoTipo : AuditableEntity<Guid>, ITenantObrigatorio //BaseIdTenantEntity // AuditableEntity<Guid>
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public Guid Id_Tenant { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;  
        public bool Inativo { get; set; }

        public AtivoTipo DadosDoIncluir()
        {
            this.Inativo = false;
            return this;
        }

        public ResultadoOperacao ValidaDados(AtivoTipo entidade)
        {
            //Valida os campos obrigatorio do mapeamento
            var validador = new AtivoTipoValidador().Validar(entidade);
            return validador;
        }
    }
}
