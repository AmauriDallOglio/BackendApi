using AutoMapper;
using BackendApi.Aplicacao.Profiles;

namespace BackendApi.Configuracao
{
    public class DependenciasDoMapper
    {
        public static void Injetar(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<TenantProfile>();
            cfg.AddProfile<AuditoriaProfile>();
            cfg.AddProfile<DefeitoProfile>();
            cfg.AddProfile<CheckListTipoProfile>();
            cfg.AddProfile<AtivoTipoProfile>();
            cfg.AddProfile<HabilidadeProfile>();
            cfg.AddProfile<AtivoLocalProfile>();
            cfg.AddProfile<AtivoProfile>();

            //Tenant(cfg);
            //Auditoria(cfg);
            //Defeito(cfg);
        }

        //private static void Auditoria(IMapperConfigurationExpression cfg)
        //{
        //    cfg.CreateMap<Auditoria, AuditoriaInserirRequest>().ReverseMap();
        //    cfg.CreateMap<Auditoria, AuditoriaInserirResponse>().ReverseMap();
        //}
        //private static void Defeito(IMapperConfigurationExpression cfg)
        //{
        //    cfg.CreateMap<Defeito, DefeitoIncluir.Request>().ReverseMap();
        //    cfg.CreateMap<Defeito, DefeitoIncluir.Response>().ReverseMap();
        //    cfg.CreateMap<Defeito, DefeitoAlterar.Request>().ReverseMap();
        //    cfg.CreateMap<Defeito, DefeitoAlterar.Response>().ReverseMap();
        //    cfg.CreateMap<Defeito, DefeitoListarTodosRequest>().ReverseMap();
        //    cfg.CreateMap<Defeito, DefeitoListarTodosResponse>().ReverseMap();
        //}

        //private static void Tenant(IMapperConfigurationExpression cfg)
        //{
        //    cfg.CreateMap<Tenant, TenantListarTodosRequest>().ReverseMap();
        //    cfg.CreateMap<Tenant, TenantListarTodosResponse>().ReverseMap();
        //    cfg.CreateMap<Tenant, TenantPorIdRequest>().ReverseMap();
        //    cfg.CreateMap<Tenant, TenantPorIdResponse>().ReverseMap();

        //    cfg.CreateMap<Tenant, TenantInserirRequest>().ReverseMap();
        //    cfg.CreateMap<Tenant, TenantInserirResponse>().ReverseMap();
        //    cfg.CreateMap<Tenant, TenantAlterarRequest>().ReverseMap();
        //    cfg.CreateMap<Tenant, TenantAlterarResponse>().ReverseMap();
        //    cfg.CreateMap<Tenant, TenantExcluirRequest>().ReverseMap();
        //    cfg.CreateMap<Tenant, TenantExcluirResponse>().ReverseMap();
        //}



    }
}
