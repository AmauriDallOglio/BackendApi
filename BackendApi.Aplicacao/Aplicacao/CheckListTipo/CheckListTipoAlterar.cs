using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Util;
using MediatR;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace BackendApi.Aplicacao.Aplicacao.CheckListTipo
{
    public class CheckListTipoAlterar : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }

    internal class CheckListTipoAlterarHandler : IRequestHandler<CheckListTipoAlterar, Guid>
    {
        private readonly ICheckListTipoRepositorio _iCheckListTipoRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CheckListTipoAlterarHandler(IMediator mediator, IMapper mapper, ICheckListTipoRepositorio repository)
        {
            _iCheckListTipoRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CheckListTipoAlterar request, CancellationToken cancellationToken)
        {
            var entidadeMapeada = _mapper.Map<Dominio.Entidade.CheckListTipo>(request);
            var entidadeBanco = _iCheckListTipoRepositorio.ObterPorId(request.Id);
            entidadeBanco.Descricao = request.Descricao;
            entidadeBanco.Referencia = request.Referencia;
            Dominio.Entidade.CheckListTipo entidadeBancoAlterada = _iCheckListTipoRepositorio.Alterar(entidadeBanco, true);

            string json = JsonConvertSerializeObject(entidadeBancoAlterada);
            InserirLogAuditoria(entidadeBancoAlterada.Id_Tenant, entidadeBancoAlterada.Id, json);
            InserirLogAuditoriaGenerico(entidadeBancoAlterada.Id_Tenant, entidadeBancoAlterada.Id, json, "teste");
            return await Task.FromResult(entidadeBanco.Id);
        }

        private async Task InserirLogAuditoria(Guid idTenante, Guid idRegistroAtual, string json)
        {
  
            var auditoria = new AuditoriaInserirRequest
            {
                IdTenant = idTenante,
                IdRegistro = idRegistroAtual,
                NomeTabela = "CheckListTipo",
                ModoCrud = (short)ModoCruds.Alterar,
                Json = json
            };

            await _mediator.Send(auditoria);
        }

        private async Task InserirLogAuditoriaGenerico<T>(Guid idTenante, Guid idRegistroAtual, string json, T entidadeBancoAlterada)
        {

            var auditoria = new AuditoriaGenerico<T>
            {
 
                Dados = entidadeBancoAlterada
            };

            await _mediator.Send(auditoria);
        }


        public string JsonConvertSerializeObject(Dominio.Entidade.CheckListTipo dto)
        {
            string jsonData = JsonConvert.SerializeObject(dto);
            return jsonData;
        }


    }

}
