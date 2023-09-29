using Microsoft.EntityFrameworkCore;

namespace BackendApi.Infra.Mapeamento.Configuracao
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
            builder.ApplyConfiguration(new AtivoMapeamento());
        }
    }
}
