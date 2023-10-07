using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.AtivoLocal.Command;
using BackendApi.Aplicacao.Aplicacao.AtivoLocal.Queries;
using BackendApi.Aplicacao.Validador;
using BackendApi.Dominio.Entidade;

namespace BackendApi.Aplicacao.Profiles
{
    public class AtivoLocalProfile : Profile
    {
        public AtivoLocalProfile()
        {
            CreateMap<AtivoLocal, AtivoLocalInserirCommand>().ReverseMap();
            CreateMap<AtivoLocal, AtivoLocalAlterarCommand>().ReverseMap();
            CreateMap<AtivoLocal, AtivoLocalExcluirCommand>().ReverseMap();
            CreateMap<AtivoLocal, AtivoLocalListarTodosQueries>().ReverseMap();
            CreateMap<AtivoLocal, AtivoLocalListarTodosResponseQueries>().ReverseMap();
            //CreateMap<AtivoLocalInserirCommand, AtivoLocalInserirValidador>().ReverseMap();
     



        }
    }
}
