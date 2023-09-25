using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Aplicacao.Interface;
using BackendApi.Aplicacao.Modelo;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Util;
using BackendApi.Dominio.Validador;
using MediatR;
using Newtonsoft.Json;

namespace BackendApi.Aplicacao.Aplicacao.CheckListTipo
{

    public class CheckListTipoInserirHandler : IRequestHandler<CheckListTipoInserirRequest, ResultadoOperacao<CheckListTipoInserirResponse>>
    {
        private readonly ICheckListTipoRepositorio _iCheckListTipoRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CheckListTipoInserirHandler(IMediator mediator, IMapper mapper, ICheckListTipoRepositorio repository)
        {
            _iCheckListTipoRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<CheckListTipoInserirResponse>> Handle(CheckListTipoInserirRequest request, CancellationToken cancellationToken)
        {
            var resultadoOperacao = CriarResultadoOperacao();
            var entidade = _mapper.Map<Dominio.Entidade.CheckListTipo>(request);

            var validador = ValidaMapeamento(entidade);
            if (validador.Sucesso == false)
            {
                resultadoOperacao.Sucesso = validador.Sucesso;
                resultadoOperacao.Mensagem = validador.Mensagem;
                return Task.FromResult(resultadoOperacao);
            }

            var entidadeBD = _iCheckListTipoRepositorio.Inserir(entidade, true);
            CheckListTipoInserirResponse dto = _mapper.Map<CheckListTipoInserirResponse>(entidadeBD);
            resultadoOperacao.Modelo = dto;

            SerializacaoJsonAplicacao serializacao = new SerializacaoJsonAplicacao();

            string json = serializacao.RetornaJson(dto); //JsonConvertSerializeObject(dto);
           // InserirAuditoria(dto.Id, dto.Id, json);

            return Task.FromResult(resultadoOperacao);
        }

        //public async Task InserirAuditoria(Guid idTenante, Guid idRegistroAtual, string json)
        //{
        //    AuditoriaInserirRequest auditoria = new AuditoriaInserirRequest { IdTenant = idTenante, IdRegistro = idRegistroAtual, NomeTabela = "CheckListTipo", ModoCrud = (short)ModoCruds.Inserir, Json = json };
        //    _mediator.Send(auditoria);
        //}

        public ResultadoOperacao<CheckListTipoInserirResponse> CriarResultadoOperacao()
        {
            ResultadoOperacao<CheckListTipoInserirResponse> resultadoOperacao = new ResultadoOperacao<CheckListTipoInserirResponse>(null)
            {
                Sucesso = true,
                Mensagem = ""
            };
            return resultadoOperacao;
        }
        public ResultadoOperacao<Dominio.Entidade.CheckListTipo> ValidaMapeamento(Dominio.Entidade.CheckListTipo entidade)
        {
            ResultadoOperacao<Dominio.Entidade.CheckListTipo> validador = new CheckListTipoValidador().Validar(entidade);
            return validador;
        }

        public string JsonConvertSerializeObject(CheckListTipoInserirResponse dto)
        {
            string jsonData = JsonConvert.SerializeObject(dto);
            return jsonData;
        }


    }
}