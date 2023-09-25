using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.AtivoLocal;
using BackendApi.Dominio.Entidade;

namespace BackendApi.Aplicacao.Profiles
{
    public class AtivoLocalProfile : Profile
    {
        public AtivoLocalProfile()
        {
            CreateMap<AtivoLocal, AtivoLocalInserir>().ReverseMap();
            CreateMap<AtivoLocal, AtivoLocalAlterar>().ReverseMap();
            CreateMap<AtivoLocal, AtivoLocalExcluir>().ReverseMap();
            CreateMap<AtivoLocal, AtivoLocalListarTodos>().ReverseMap();
            CreateMap<AtivoLocal, AtivoLocalListarTodosResponse>().ReverseMap();
        }
    }
}
