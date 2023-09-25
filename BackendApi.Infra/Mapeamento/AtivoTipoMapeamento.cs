using BackendApi.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Infra.Mapeamento
{
    public class AtivoTipoMapeamento : IEntityTypeConfiguration<AtivoTipo>
    {
        public void Configure(EntityTypeBuilder<AtivoTipo> builder)
        {
            builder.ToTable("AtivoTipo"); // Especifica o nome da tabela no banco de dados
            builder.HasKey(a => a.Id); // Define a chave primária
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("Id").HasColumnType("Guid").IsRequired(true);
            builder.Property(a => a.Id_Tenant).HasColumnName("Id_Tenant").HasColumnType("Guid").IsRequired(true);
            builder.Property(a => a.Referencia).HasColumnName("Referencia").HasMaxLength(50).HasColumnType("varchar").IsRequired(true);
            builder.Property(a => a.Descricao).HasColumnName("Descricao").HasMaxLength(300).HasColumnType("varchar").IsRequired(true);
            builder.Property(a => a.Inativo).HasColumnName("Inativo").HasColumnType("bool").HasMaxLength(1).IsRequired(true);


            //builder.ToTable("AtivoTipo"); // Especifica o nome da tabela no banco de dados
            //builder.HasKey(a => a.Id); // Define a chave primária
            //builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("Id").IsRequired(true);
            //builder.Property(a => a.Id_Tenant).HasColumnName("Id_Tenant").HasColumnType("Guid").IsRequired(true);
            //builder.Property(a => a.Referencia).HasMaxLength(50).HasColumnName("Referencia").IsRequired(true);
            //builder.Property(a => a.Descricao).HasMaxLength(300).HasColumnName("Descricao").IsRequired(true);
            //builder.Property(a => a.Inativo).HasColumnName("Inativo").IsRequired(true);
        }
    }
}
