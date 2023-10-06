using BackendApi.Dominio.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.Infra.Repositorio.Configuracao
{
    public abstract class ConfiguracaoFiltro
    {
        private readonly Guid _globalIdTenant;

        public ConfiguracaoFiltro(Guid globalIdTenant)
        {
            _globalIdTenant = globalIdTenant;
        }

        protected void ConfiguraTenantFiltroGuid<T>(ModelBuilder modelBuilder) where T : AuditableEntity<Guid>, ITenantObrigatorio
        {
            modelBuilder.Entity<T>().HasQueryFilter(x => x.Id == _globalIdTenant);
        }
    }
}
