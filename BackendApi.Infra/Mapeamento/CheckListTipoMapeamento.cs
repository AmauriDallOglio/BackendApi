using BackendApi.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.Infra.Mapeamento
{
    public class CheckListTipoMapeamento : IEntityTypeConfiguration<CheckListTipo>
    {
        public void Configure(EntityTypeBuilder<CheckListTipo> builder)
        {
            builder.ToTable("CheckListTipo");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id").IsRequired().HasColumnType("Guid");

            builder.Property(s => s.Id_Tenant).HasColumnName("Id_Tenant").HasColumnType("Guid").IsRequired(true);
            builder.HasOne(x => x.Tenant).WithMany().HasForeignKey(x => x.Id_Tenant);
            //builder.HasOne(s => s.TenantAuditoria).WithMany(a => a.Auditorias).HasForeignKey(e => e.Id_Tenant);

            builder.Property(s => s.Referencia).HasColumnName("Referencia").HasColumnType("varchar").HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(s => s.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(300).IsRequired(true);
            builder.Property(s => s.Inativo).HasColumnName("Inativo").HasColumnType("bool").HasMaxLength(1).IsRequired(true);
  
        }
    }
}
