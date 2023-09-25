using BackendApi.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Infra.Mapeamento
{
    public class TenantMapeamento : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable("Tenant");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id").IsRequired().HasColumnType("guid");

            builder.Property(s => s.Referencia).HasColumnName("Referencia").HasColumnType("varchar").HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(s => s.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(300).IsRequired(true);
            builder.Property(s => s.Id_Imagem).HasColumnName("Id_Imagem").HasColumnType("guid").IsRequired(false);
            builder.Property(s => s.Inativo).HasColumnName("Inativo").HasColumnType("bool").HasMaxLength(1).IsRequired(true);

        }
    }
}
