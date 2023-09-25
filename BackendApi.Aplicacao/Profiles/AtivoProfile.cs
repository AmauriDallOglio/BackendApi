using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Ativo;
using BackendApi.Dominio.Entidade;

namespace BackendApi.Aplicacao.Profiles
{
    public class AtivoProfile : Profile
    {
        public AtivoProfile() 
        {
            CreateMap<Ativo, AtivoListarTodos>().ReverseMap();
            CreateMap<Ativo, AtivoListarTodosResponse>().ReverseMap();
        }
    }
}
