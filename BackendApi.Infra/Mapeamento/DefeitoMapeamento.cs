using BackendApi.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Infra.Mapeamento
{
    public class DefeitoMapeamento : IEntityTypeConfiguration<Defeito>
    {
        public void Configure(EntityTypeBuilder<Defeito> builder)
        {
            builder.ToTable("Defeito");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("Id").IsRequired().HasColumnType("Guid");
            builder.Property(s => s.Id_Tenant).HasColumnName("Id_Tenant").HasColumnType("Guid").IsRequired(true);
            //builder.HasOne(x => x.Tenant).WithMany().HasForeignKey(x => x.Id_Tenant);
            //builder.HasOne(s => s.TenantAuditoria).WithMany(a => a.Auditorias).HasForeignKey(e => e.Id_Tenant);
            builder.Property(s => s.Referencia).HasColumnName("Referencia").HasColumnType("varchar").HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(s => s.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(300).IsRequired(true);
            builder.Property(s => s.Inativo).HasColumnName("Inativo").HasColumnType("bool").HasMaxLength(1).IsRequired(true);
            builder.Property(s => s.TipoDefeito).HasColumnName("TipoDefeito").HasColumnType("byte").HasMaxLength(1).IsRequired(true);


        }
    }
}
