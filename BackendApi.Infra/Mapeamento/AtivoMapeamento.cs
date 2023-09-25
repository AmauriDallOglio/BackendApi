using BackendApi.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Infra.Mapeamento
{
    public class AtivoMapeamento : IEntityTypeConfiguration<Ativo>
    {
        public void Configure(EntityTypeBuilder<Ativo> builder)
        {
            builder.ToTable("Ativo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWSEQUENTIALID()")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Id_Tenant)
                .HasColumnName("Id_Tenant")
                .HasColumnType("uniqueidentifier")
                .IsRequired(true);


            builder.HasOne(a => a.Tenant) // A propriedade virtual Tenant em Ativo
                    .WithMany(t => t.Ativos) // A propriedade de navegação ICollection<Ativo> em Tenant
                    .HasForeignKey(a => a.Id_Tenant); // A chave estrangeira em Ativo


            builder.Property(a => a.Id_AtivoLocal)
                .HasColumnName("Id_AtivoLocal")
                .HasColumnType("uniqueidentifier")
                .IsRequired(true);

            builder.Property(a => a.Id_AtivoTipo)
                .HasColumnName("Id_AtivoTipo")
                .HasColumnType("uniqueidentifier")
                .IsRequired(true);

            builder.Property(a => a.Id_AtivoPai)
                .HasColumnName("Id_AtivoPai")
                .HasColumnType("uniqueidentifier")
                .IsRequired(false);

            builder.Property(a => a.Referencia)
                .HasColumnName("Referencia")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(a => a.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired(true);

            builder.Property(a => a.Fabricante)
                .HasColumnName("Fabricante")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired(false);

            builder.Property(a => a.Modelo)
                .HasColumnName("Modelo")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired(false);


            builder.Property(a => a.NumeroSerie)
                .HasColumnName("NumeroSerie")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired(false);

            builder.Property(a => a.AnoFabricacao)
                .HasColumnName("AnoFabricacao")
                .HasColumnType("varchar")
                .HasMaxLength(4)
                .IsRequired(false);

            builder.Property(a => a.Inativo)
                .HasColumnName("Inativo")
                .HasColumnType("bool")
                .HasMaxLength(1)
                .IsRequired(true);

      


            builder.Property(a => a.NumeroPatrimonial)
                .HasColumnName("NumeroPatrimonial")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(a => a.DataAquisicao)
                .HasColumnName("DataAquisicao")
                .HasColumnType("datetime")
                .HasMaxLength(15)
                .IsRequired(false);

            builder.Property(a => a.CentroCusto)
                .HasColumnName("CentroCusto")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(a => a.SituacaoAtivo)
                .HasColumnName("SituacaoAtivo")
                .HasColumnType("byte")
                .HasMaxLength(1)
                .IsRequired(true);

            builder.Property(a => a.Periodicidade)
                .HasColumnName("Periodicidade")
                .HasColumnType("byte")
                .HasMaxLength(1)
                .IsRequired(true);
        }
    }
}
