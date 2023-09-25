using BackendApi.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Infra.Mapeamento
{
    public class AuditoriaMapeamento : IEntityTypeConfiguration<Auditoria>
    {
        public void Configure(EntityTypeBuilder<Auditoria> builder)
        {
            builder.ToTable("Auditoria");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).IsRequired().HasColumnName("Id").HasColumnType("guid");


            builder.Property(s => s.Id_Tenant).HasColumnName("Id_Tenant").HasColumnType("Guid").IsRequired(false);
           // builder.HasOne(x => x.TenantAuditoria).WithMany().HasForeignKey(x => x.Id_Tenant);
            //builder.HasOne(s => s.TenantAuditoria).WithMany(a => a.Auditorias).HasForeignKey(e => e.Id_Tenant);

            builder.Property(s => s.NomeTabela).HasColumnName("NomeTabela").HasColumnType("varchar").HasMaxLength(50).IsRequired(true);
            builder.Property(s => s.ModoCrud).HasColumnName("ModoCrud").HasColumnType("varchar").HasMaxLength(15).IsRequired(true);
            builder.Property(s => s.DataCadastro).HasColumnName("DataCadastro").HasColumnType("datetime").HasMaxLength(15).IsRequired(true);
            builder.Property(s => s.HistoricoAntes).HasColumnName("HistoricoAntes").HasColumnType("string").HasMaxLength(500).IsRequired(false);
            builder.Property(s => s.HistoricoDepois).HasColumnName("HistoricoDepois").HasColumnType("string").HasMaxLength(500).IsRequired(false);

        }
    }
}
