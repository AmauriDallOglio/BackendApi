using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.Modelo;
using BackendApi.Infra.Mapeamento.Configuracao;
using BackendApi.Infra.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace BackendApi.Infra.Context
{
    public class MeuContext : DbContext
    {
        private readonly Global _Global;
        public MeuContext(DbContextOptions<MeuContext> options, Global global) : base(options)
        {
            _Global = global;
        }

        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<Auditoria> Auditoria { get; set; }
        public DbSet<Defeito> Defeito { get; set; }
        public DbSet<CheckListTipo> CheckListTipo { get; set; }
        public DbSet<AtivoTipo> AtivoTipo { get; set; }
        public DbSet<Habilidade> Habilidade { get; set; }
        public DbSet<AtivoLocal> AtivoLocal { get; set; }
        public DbSet<Ativo> Ativo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfiguracaoMapeamento.Injetar(modelBuilder);    
            ConfiguracaoFiltro.Injetar(modelBuilder, _Global);

            base.OnModelCreating(modelBuilder);

             

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var teste = "";

            foreach (var entry in ChangeTracker.Entries<Dominio.Modelo.IAuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        CompleteForCreated(entry.Entity);
                        break;

                    case EntityState.Modified:
                        CompleteForUpdated(entry.Entity);
                        break;
                }
            }
            if (_Global.Id_Usuario == null)
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return await base.SaveChangesAsync(true, cancellationToken);
            }

        }


        protected void CompleteForCreated(object entity)
        {
            if (entity is Dominio.Modelo.ITenantObrigatorio)
                SetTenantId(entity as Dominio.Modelo.ITenantObrigatorio);
        }

        protected void CompleteForUpdated(object entity)
        {
            if (entity is Dominio.Modelo.ITenantObrigatorio)
                SetTenantId(entity as Dominio.Modelo.ITenantObrigatorio);
        }
        private void SetTenantId(Dominio.Modelo.ITenantObrigatorio entity)
        {
            if (Guid.Empty.Equals(entity.Id_Tenant))
                entity.Id_Tenant = _Global.Id_Tenant_Global;
        }
    }
}
