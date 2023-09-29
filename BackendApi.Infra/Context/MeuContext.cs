﻿using BackendApi.Dominio.Entidade;
using BackendApi.Infra.Mapeamento.Configuracao;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Infra.Context
{
    public class MeuContext : DbContext
    {
        public MeuContext(DbContextOptions<MeuContext> options) : base(options)
        {
        
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
