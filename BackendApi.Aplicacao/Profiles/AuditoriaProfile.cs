using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Dominio.Entidade;

namespace BackendApi.Aplicacao.Profiles
{
    public class AuditoriaProfile : Profile //AuditoriaProfile<T> : Profile
    {
        public AuditoriaProfile()
        {

            //Mapeamento de Auditoria para AuditoriaInserirRequest<T>
            CreateMap<Auditoria, AuditoriaGenerico<string>>().ReverseMap();
 

            CreateMap<Auditoria, AuditoriaInserirRequest>().ReverseMap();
            CreateMap<Auditoria, AuditoriaInserirResponse>().ReverseMap();

 

        }
    }
}
