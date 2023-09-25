using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Validador;

namespace BackendApi.Dominio.Entidade
{
    public class AtivoLocal
    {
        public Guid Id { get; set; } // Tipo: UNIQUEIDENTIFIER
        public Guid Id_Tenant { get; set; } // Tipo: uniqueidentifier
        public string Referencia { get; set; } = string.Empty;  // Tipo: varchar(50)
        public string Area { get; set; } = string.Empty; // Tipo: varchar(50)
        public string Setor { get; set; } = string.Empty; // Tipo: varchar(50)
        public string Descricao { get; set; } = string.Empty; // Tipo: varchar(300)
        public bool Inativo { get; set; } // Tipo: bit

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
