using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Util;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BackendApi.Aplicacao.Aplicacao.AtivoTipo.AtivoTipoExcluir;

namespace BackendApi.Aplicacao.Aplicacao.AtivoTipo
{
    public class AtivoTipoExcluir : IRequest<ResultadoOperacao<RespostaExcluir>>
    {
 
        public Guid Id { get; set; }

    }

    public class RespostaExcluir
    {
        public Guid Id { get; set; }

    }

    internal class AtivoTipoExcluirHandler : IRequestHandler<AtivoTipoExcluir, ResultadoOperacao<RespostaExcluir>>
    {
        private readonly IAtivoTipoRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AtivoTipoExcluirHandler(IMediator mediator, IMapper mapper, IAtivoTipoRepositorio repository)
        {
            _repositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<RespostaExcluir>> Handle(AtivoTipoExcluir request, CancellationToken cancellationToken)
        {
            //Busca entidade no banco
            Dominio.Entidade.AtivoTipo entidadeBD = _repositorio.ObterPorId(request.Id);

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
            _repositorio.Deletar(entidadeBD);

            //Gera registro de historico na tabela de auditoria
            AuditoriaObjetoJson auditoriaObjetoJson = new AuditoriaObjetoJson();
            var objAuditoria = auditoriaObjetoJson.Criar(entidadeBD, entidadeBD.Id_Tenant, entidadeBD.Id, "AtivoTipo", ModoCruds.Excluir);
            _mediator.Send(objAuditoria.Result);

            var sucesso = ConverterMensagem(validador, entidadeBD);
            return await Task.FromResult(sucesso);
        }

        public ResultadoOperacao<RespostaExcluir> ConverterMensagem(ResultadoOperacao resultado, Dominio.Entidade.AtivoTipo entidadeBD)
        {
            var retorno = new ResultadoOperacao<RespostaExcluir>(new RespostaExcluir { Id = entidadeBD.Id });
            retorno.Sucesso = resultado.Sucesso;
            retorno.Mensagem = resultado.Mensagem;
            return retorno;
        }
    }
    
}
