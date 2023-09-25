using AutoMapper;
using BackendApi.Dominio.InterfaceRepositorio;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Tenant
{
    public class TenantPorIdHandler : IRequestHandler<TenantPorIdRequest, TenantPorIdResponse> 
    {
        private readonly ITenantRepositorio _iTenantRepositorio;
        private readonly IMapper _mapper;

        public TenantPorIdHandler(ITenantRepositorio repository, IMapper mapper)
        {
            _iTenantRepositorio = repository;
            _mapper = mapper;
        }

        public async Task<TenantPorIdResponse> Handle(TenantPorIdRequest request, CancellationToken cancellationToken)
        {
            Dominio.Entidade.Tenant tenant = _iTenantRepositorio.ObterPorId(request.Id);
            var resultado = _mapper.Map<TenantPorIdResponse>(tenant);
            return await Task.FromResult(resultado);
        }
 

    }
}
