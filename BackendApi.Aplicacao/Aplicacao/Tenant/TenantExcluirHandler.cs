using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Util;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Tenant
{
    public class TenantExcluirHandler : IRequestHandler<TenantExcluirRequest, TenantExcluirResponse>
    {
        private readonly ITenantRepositorio _iTenantRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TenantExcluirHandler(IMapper mapper, IMediator mediator, ITenantRepositorio repository)
        {
            _iTenantRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<TenantExcluirResponse> Handle(TenantExcluirRequest request, CancellationToken cancellationToken)
        {
            var tenant = _iTenantRepositorio.ObterPorId(request.Id);
            //InserirLogAuditoria(tenant.Id, tenant.Id);
            var resultado = _iTenantRepositorio.Deletar(tenant);

            TenantExcluirResponse retorno = _mapper.Map<TenantExcluirResponse>(resultado);
            return await Task.FromResult(retorno);
        }

        //private async Task InserirLogAuditoria(Guid idTenante, Guid idRegistroAtual)
        //{
        //    AuditoriaInserirRequest auditoria = new AuditoriaInserirRequest { IdTenant = idTenante, IdRegistro = idRegistroAtual, NomeTabela = "Tenant", ModoCrud = (short)ModoCruds.Excluir };
        //    await _mediator.Send(auditoria);
        //}

    }
}
