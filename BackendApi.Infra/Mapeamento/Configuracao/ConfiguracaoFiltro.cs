using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Infra.Mapeamento.Configuracao
{
    public class ConfiguracaoFiltro
    {

        public static void Injetar(ModelBuilder builder, Global global)
        {
            AplicarFiltroGlobalIdInterno2<Tenant>(builder, global);
            AplicarFiltroGlobalIdExterno2<AtivoTipo>(builder, global);
            AplicarFiltroGlobalIdExterno2<AtivoLocal>(builder, global);
            AplicarFiltroGlobalIdExterno2<Ativo>(builder, global);
            AplicarFiltroGlobalIdExterno2<Auditoria>(builder, global);
            AplicarFiltroGlobalIdExterno2<Defeito>(builder, global);
            AplicarFiltroGlobalIdExterno2<CheckListTipo>(builder, global);
            AplicarFiltroGlobalIdExterno2<Habilidade>(builder, global);

        }

        private static void AplicarFiltroGlobalIdInterno<TEntity>(ModelBuilder modelBuilder, Global global) where TEntity : BaseIdEntity
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => e.Id == global.Id_Tenant_Global).Property(a => a.Id).HasColumnName("Id");
        }

        private static void AplicarFiltroGlobalIdInterno2<TEntity>(ModelBuilder modelBuilder, Global global) where TEntity : AuditableEntity<Guid> //, ITenantObrigatorio
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => e.Id == global.Id_Tenant_Global).Property(a => a.Id).HasColumnName("Id");
        }

        private static void AplicarFiltroGlobalIdExterno<TEntity>(ModelBuilder modelBuilder, Global global) where TEntity : BaseIdTenantEntity
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => e.Id_Tenant == global.Id_Tenant_Global).Property(a => a.Id_Tenant).HasColumnName("Id_Tenant");
        }

        private static void AplicarFiltroGlobalIdExterno2<TEntity>(ModelBuilder modelBuilder, Global global) where TEntity : AuditableEntity<Guid>, ITenantObrigatorio
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => e.Id_Tenant == global.Id_Tenant_Global).Property(a => a.Id_Tenant).HasColumnName("Id_Tenant");
        }

    }
}