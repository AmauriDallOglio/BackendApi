using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Aplicacao.Interface;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Util;
using BackendApi.Dominio.Validador;
using MediatR;
using Newtonsoft.Json;
using System;

namespace BackendApi.Aplicacao.Aplicacao.Tenant
{
    public class TenantInserirHandler : IRequestHandler<TenantInserirRequest, ResultadoOperacao<TenantInserirResponse>>, ITenantInserirAplicacao
    {
        private readonly ITenantRepositorio _iTenantRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TenantInserirHandler(IMediator mediator, IMapper mapper, ITenantRepositorio repository)
        {
            _iTenantRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<TenantInserirResponse>> Handle(TenantInserirRequest request, CancellationToken cancellationToken)
        {
            var resultadoOperacao = CriarResultadoOperacao();
            var entidade = _mapper.Map<Dominio.Entidade.Tenant>(request);

            var validador = ValidaMapeamento(entidade);
            if (validador.Sucesso == false)
            {
                resultadoOperacao.Sucesso = validador.Sucesso;
                resultadoOperacao.Mensagem = validador.Mensagem;
                return Task.FromResult(resultadoOperacao);
            }

            var entidadeBD = _iTenantRepositorio.Inserir(entidade, true);
            TenantInserirResponse dto = _mapper.Map<TenantInserirResponse>(entidadeBD);
            resultadoOperacao.Modelo = dto;

            string json = JsonConvertSerializeObject(dto);
         //   InserirAuditoria(dto.Id, dto.Id, json);

            return Task.FromResult(resultadoOperacao);
        }

        //public async Task InserirAuditoria(Guid idTenante, Guid idRegistroAtual, string json)
        //{
        //    AuditoriaInserirRequest auditoria = new AuditoriaInserirRequest { IdTenant = idTenante, IdRegistro = idRegistroAtual, NomeTabela = "Tenant", ModoCrud = (short)ModoCruds.Inserir, Json = json };
        //    _mediator.Send(auditoria);
        //}

        public ResultadoOperacao<TenantInserirResponse> CriarResultadoOperacao()
        {
            ResultadoOperacao<TenantInserirResponse> resultadoOperacao = new ResultadoOperacao<TenantInserirResponse>(null)
            {
                Sucesso = true,
                Mensagem = ""
            };
            return resultadoOperacao;
        }
        public ResultadoOperacao<Dominio.Entidade.Tenant> ValidaMapeamento(Dominio.Entidade.Tenant entidade)
        {
            ResultadoOperacao<Dominio.Entidade.Tenant> validador = new TenantValidador().Validar(entidade);
            return validador;
        }

        public string JsonConvertSerializeObject(TenantInserirResponse dto)
        {
            string jsonData = JsonConvert.SerializeObject(dto);
            return jsonData;
        }

    
    }
}