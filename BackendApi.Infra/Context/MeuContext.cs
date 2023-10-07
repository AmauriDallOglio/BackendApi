using BackendApi.Dominio.Entidade;
using BackendApi.Infra.Mapeamento.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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



        public void MetodoInserir()
        {
            foreach (EntityEntry entry in ChangeTracker.Entries<Dominio.Modelo.IAuditableEntity>().ToList())
            {
                object objeto = entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                        InserirInformacaoGlobal(objeto);
                        break;
                }
            }
        }

        public void MetodoAlterar()
        {
            foreach (EntityEntry entry in ChangeTracker.Entries<Dominio.Modelo.IAuditableEntity>().ToList())
            {
                object objeto = entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Modified:
                        InserirInformacaoGlobal(objeto);
                        break;
                }
            }
        }


 

        protected void InserirInformacaoGlobal(object entity)
        {
            if (entity is Dominio.Modelo.ITenantObrigatorio)
                SetaTenantId(entity as Dominio.Modelo.ITenantObrigatorio);
        }

    
        private void SetaTenantId(Dominio.Modelo.ITenantObrigatorio entity)
        {
            if (Guid.Empty.Equals(entity.Id_Tenant))
                entity.Id_Tenant = _Global.Id_Tenant_Global;
        }
    }
}
