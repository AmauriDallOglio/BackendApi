﻿using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Util;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.AtivoLocal.Command
{
    public class AtivoLocalAlterarCommand : IRequest<ResultadoOperacao<AtivoLocalAlterarResposta>>
    {
        public Guid Id { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }

    public class AtivoLocalAlterarResposta
    {
        public Guid Id { get; set; }

    }

    internal class AtivoLocalAlterarHandler : IRequestHandler<AtivoLocalAlterarCommand, ResultadoOperacao<AtivoLocalAlterarResposta>>
    {
        private readonly IAtivoLocalRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AtivoLocalAlterarHandler(IMediator mediator, IMapper mapper, IAtivoLocalRepositorio repository)
        {
            _repositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<AtivoLocalAlterarResposta>> Handle(AtivoLocalAlterarCommand request, CancellationToken cancellationToken)
        {
            //Busca entidade no banco
            Dominio.Entidade.AtivoLocal entidadeBD = _repositorio.ObterPorId(request.Id);

            //Atualiza dados com as informações da tela
            _mapper.Map(request, entidadeBD);

            //Valida os campos obrigatorio do mapeamento
            ResultadoOperacao validador = entidadeBD.ValidaDados(entidadeBD);
            if (validador.Sucesso == false)
            {
                var erro = ConverterMensagem(validador, entidadeBD);
                return await Task.FromResult(erro);
            }

            //Grava no bando de dados
            _repositorio.Alterar(entidadeBD, true);

            //Gera registro de historico na tabela de auditoria
            AuditoriaObjetoJson auditoriaObjetoJson = new AuditoriaObjetoJson();
            var objAuditoria = auditoriaObjetoJson.Criar(entidadeBD, entidadeBD.Id_Tenant, entidadeBD.Id, "AtivoLocal", ModoCruds.Alterar);
            _mediator.Send(objAuditoria.Result);

            var sucesso = ConverterMensagem(validador, entidadeBD);
            return await Task.FromResult(sucesso);
        }

        public ResultadoOperacao<AtivoLocalAlterarResposta> ConverterMensagem(ResultadoOperacao resultado, Dominio.Entidade.AtivoLocal entidadeBD)
        {
            var retorno = new ResultadoOperacao<AtivoLocalAlterarResposta>(new AtivoLocalAlterarResposta { Id = entidadeBD.Id });
            retorno.Sucesso = resultado.Sucesso;
            retorno.Mensagem = resultado.Mensagem;
            return retorno;
        }
    }
}
