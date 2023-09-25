namespace BackendApi.Dominio.Entidade
{
    public class Ativo 
    {
        public Guid Id { get; set; } // Id UNIQUEIDENTIFIER
        public Guid Id_Tenant { get; set; } // Id_Tenant uniqueidentifier
        public virtual Tenant Tenant { get; set; }

        public Guid Id_AtivoLocal { get; set; } // Id_AtivoLocal uniqueidentifier
        public Guid Id_AtivoTipo { get; set; } // Id_AtivoTipo uniqueidentifier
        public Guid? Id_AtivoPai { get; set; } // Id_AtivoPai uniqueidentifier (pode ser nulo)
        public string Referencia { get; set; } = string.Empty; // Referencia varchar(50)
        public string Descricao { get; set; } = string.Empty; // Descricao varchar(300)
        public string? Fabricante { get; set; } = string.Empty; // Fabricante varchar(300) (pode ser nulo)
        public string? Modelo { get; set; } = string.Empty; // Modelo varchar(300) (pode ser nulo)
        public string? NumeroSerie { get; set; } = string.Empty; // NumeroSerie varchar(300) (pode ser nulo)
        public string? AnoFabricacao { get; set; } = string.Empty; // AnoFabricacao varchar(4) (pode ser nulo)
        public bool Inativo { get; set; } // Inativo bit default 0 NOT NULL
        public string NumeroPatrimonial { get; set; } = string.Empty; // NumeroPatrimonial varchar(100)
        public DateTime? DataAquisicao { get; set; } // DataAquisicao datetime (pode ser nulo)
        public string? CentroCusto { get; set; } = string.Empty; // CentroCusto varchar(100) (pode ser nulo)
        public byte SituacaoAtivo { get; set; } // SituacaoAtivo tinyint NOT NULL
        public byte Periodicidade { get; set; } // Periodicidade tinyint NOT NULL

    }

    public enum SituacaoAtivo
    {
        Proprio = 0,
        Alugado = 1,
        Hipotecado = 2,
        Vendido = 3,
        Quebrado = 4,
        Normal = 5,
        Penhorado = 6,
        Outros = 7
    }

    public enum Periodicidade
    {
        Nenhuma = 0,
        Diaria = 1,
        Semanal = 2,
        Quinzenal = 3,
        Mensal = 4,
        Bimestral = 5,
        Trimestral = 6,
        Quadrimestral = 7,
        Semestral = 8,
        Anual = 9
    }



}
