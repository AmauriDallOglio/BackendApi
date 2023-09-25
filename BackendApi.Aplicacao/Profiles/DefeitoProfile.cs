using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Defeito;
using BackendApi.Dominio.Entidade;

namespace BackendApi.Aplicacao.Profiles
{
    public class DefeitoProfile : Profile
    {
        public DefeitoProfile()
        {
            CreateMap<Defeito, DefeitoIncluir.Request>().ReverseMap();
            CreateMap<Defeito, DefeitoIncluir.Response>().ReverseMap();
            CreateMap<Defeito, DefeitoAlterar.Request>().ReverseMap();
            CreateMap<Defeito, DefeitoAlterar.Response>().ReverseMap();
            CreateMap<Defeito, DefeitoListarTodosRequest>().ReverseMap();
            CreateMap<Defeito, DefeitoListarTodosResponse>().ReverseMap();
        }
    }
}