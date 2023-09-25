using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Util;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace BackendApi.Aplicacao.Aplicacao.Tenant
{
    public class TenantAlterarHandler : IRequestHandler<TenantAlterarRequest, TenantAlterarResponse>
    {
        private readonly ITenantRepositorio _iTenantRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public TenantAlterarHandler(IMediator mediator, IMapper mapper, ITenantRepositorio repository)
        {
            _iTenantRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<TenantAlterarResponse> Handle(TenantAlterarRequest request, CancellationToken cancellationToken)
        {
            var entidadeMapeada = _mapper.Map<Dominio.Entidade.Tenant>(request);
            Dominio.Entidade.Tenant tenant = _iTenantRepositorio.Alterar(entidadeMapeada, true);
            string json = JsonConvertSerializeObject(request);
          //  InserirLogAuditoria(tenant.Id, tenant.Id, json);
            var resultado = _mapper.Map<TenantAlterarResponse>(tenant);
            return await Task.FromResult(resultado);
        }

        //private async Task InserirLogAuditoria(Guid idTenante, Guid idRegistroAtual, string json)
        //{
        //    AuditoriaInserirRequest auditoria = new AuditoriaInserirRequest { IdTenant = idTenante, IdRegistro = idRegistroAtual, NomeTabela = "Tenant", ModoCrud = (short)ModoCruds.Alterar, Json = json};
        //    await _mediator.Send(auditoria);
        //}

        public string JsonConvertSerializeObject(TenantAlterarRequest dto)
        {
            string jsonData = JsonConvert.SerializeObject(dto);
            return jsonData;
        }
    }
}
