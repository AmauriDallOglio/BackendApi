using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.CheckListTipo;
using BackendApi.Dominio.Entidade;

namespace BackendApi.Aplicacao.Profiles
{
    public class CheckListTipoProfile : Profile
    {
        public CheckListTipoProfile()
        {
            CreateMap<CheckListTipo, CheckListTipoInserirRequest>().ReverseMap();
            CreateMap<CheckListTipo, CheckListTipoInserirResponse>().ReverseMap();
            CreateMap<CheckListTipo, CheckListTipoAlterar>().ReverseMap();
    
        }
    }
}
