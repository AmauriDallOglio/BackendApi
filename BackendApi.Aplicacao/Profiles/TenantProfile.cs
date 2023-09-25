using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Tenant;
using BackendApi.Dominio.Entidade;

namespace BackendApi.Aplicacao.Profiles
{
    public class TenantProfile : Profile
    {
        public TenantProfile() 
        {
            CreateMap<Tenant, TenantListarTodosRequest>().ReverseMap();
            CreateMap<Tenant, TenantListarTodosResponse>().ReverseMap();
            CreateMap<Tenant, TenantPorIdRequest>().ReverseMap();
            CreateMap<Tenant, TenantPorIdResponse>().ReverseMap();

            CreateMap<Tenant, TenantInserirRequest>().ReverseMap();
            CreateMap<Tenant, TenantInserirResponse>().ReverseMap();
            CreateMap<Tenant, TenantAlterarRequest>().ReverseMap();
            CreateMap<Tenant, TenantAlterarResponse>().ReverseMap();
            CreateMap<Tenant, TenantExcluirRequest>().ReverseMap();
            CreateMap<Tenant, TenantExcluirResponse>().ReverseMap();
        }
    }
}
