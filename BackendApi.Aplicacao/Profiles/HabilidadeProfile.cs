using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Habilidades;
using BackendApi.Dominio.Entidade;

namespace BackendApi.Aplicacao.Profiles
{
    public class HabilidadeProfile : Profile
    {
        public HabilidadeProfile() 
        {
            CreateMap<Habilidade, HabilidadeIncluir>().ReverseMap();

        }
    }
}
