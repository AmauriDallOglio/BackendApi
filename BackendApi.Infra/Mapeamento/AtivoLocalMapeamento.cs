using BackendApi.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Infra.Mapeamento
{
    public class AtivoLocalMapeamento : IEntityTypeConfiguration<AtivoLocal>
    {
        public void Configure(EntityTypeBuilder<AtivoLocal> builder)
        {
            builder.ToTable("AtivoLocal"); // Substitua pelo nome da tabela no banco de dados, se necessário.

            builder.HasKey(e => e.Id); // Define a chave primária.

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWSEQUENTIALID()")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Id_Tenant)
                .HasColumnName("Id_Tenant")
                .HasColumnType("uniqueidentifier")
                .IsRequired(true);

            builder.Property(e => e.Referencia)
                .HasColumnName("Referencia")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.Area)
                .HasColumnName("Area")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.Setor)
                .HasColumnName("Setor")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired(true);

            builder.Property(e => e.Inativo)
                .HasColumnName("Inativo")
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired(true);
        }
    }
}
