using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Validador;

namespace BackendApi.Dominio.Entidade
{
    public class Habilidade : AuditableEntity<Guid>, ITenantObrigatorio //BaseIdTenantEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } // Tipo: UNIQUEIDENTIFIER
        public Guid Id_Tenant { get; set; } // Tipo: uniqueidentifier

        public string Referencia { get; set; } = string.Empty; // Tipo: varchar(50)
        public string Descricao { get; set; } = string.Empty; // Tipo: varchar(300)
        public bool Inativo { get; set; } // Tipo: bit

        public Habilidade DadosDoIncluir()
        {
            this.Inativo = false;
            return this;
        }

        public ResultadoOperacao ValidaDados(Habilidade entidade)
        {
            //Valida os campos obrigatorio do mapeamento
            var validador = new HabilidadeValidador().Validar(entidade);
            return validador;
        }

    }
}
