using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApi.Dominio.Entidade
{

    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid Id_Tenant { get; set; }

        [Required]
        [StringLength(50)]
        public string Referencia { get; set; }

        [Required]
        [StringLength(300)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(300)]
        public string RazaoSocial { get; set; }

        [Required]
        [StringLength(300)]
        public string NomeFantasia { get; set; }

        [StringLength(14)]
        public string Cnpj { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [StringLength(300)]
        public string PessoaContato { get; set; }

        [StringLength(300)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Telefone { get; set; }

        [StringLength(300)]
        public string Endereco { get; set; }

        [StringLength(20)]
        public string Numero { get; set; }

        [StringLength(100)]
        public string Complemento { get; set; }

        [StringLength(8)]
        public string Cep { get; set; }

        [StringLength(100)]
        public string Cidade { get; set; }

        [StringLength(2)]
        public string Estado { get; set; }

        public string Observacao { get; set; }

        public bool Inativo { get; set; }
    }
}