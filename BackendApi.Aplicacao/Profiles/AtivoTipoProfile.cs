using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.AtivoTipo;
using BackendApi.Dominio.Entidade;

namespace BackendApi.Aplicacao.Profiles
{
    public class AtivoTipoProfile : Profile
    {
        public AtivoTipoProfile() 
        {
            CreateMap<AtivoTipo, AtivoTipoInserir>().ReverseMap();
            CreateMap<AtivoTipo, AtivoTipoAlterar>().ReverseMap();
            CreateMap<AtivoTipo, AtivoTipoExcluir>().ReverseMap();
            CreateMap<AtivoTipo, AtivoTipoListarTodos>().ReverseMap();
            CreateMap<AtivoTipo, AtivoTipoListarTodosResponse>().ReverseMap();
            

        }
    }
}
