using AutoMapper;
using BackendApi.Infra.Mapeamento;
using BackendApi.Infra.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Infra.Context
{
    public class ConfiguracaoMapeamento
    {
        public static void Injetar(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuditoriaMapeamento());
            builder.ApplyConfiguration(new TenantMapeamento());
            builder.ApplyConfiguration(new DefeitoMapeamento());
            builder.ApplyConfiguration(new CheckListTipoMapeamento());
            builder.ApplyConfiguration(new AtivoTipoMapeamento());
            builder.ApplyConfiguration(new HabilidadeMapeamento());
            builder.ApplyConfiguration(new AtivoLocalMapeamento());
        }
    }
}
