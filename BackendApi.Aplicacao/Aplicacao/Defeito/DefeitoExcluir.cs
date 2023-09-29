using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Util;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Defeito
{
    public class DefeitoExcluir : IRequest<ResultadoOperacao<DefeitoExcluirResposta>>
    {

        public Guid Id { get; set; }

    }

    public class DefeitoExcluirResposta
    {
        public Guid Id { get; set; }

    }


    internal class DefeitoExcluirHandler : IRequestHandler<DefeitoExcluir, ResultadoOperacao<DefeitoExcluirResposta>>
    {
        private readonly IDefeitoRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DefeitoExcluirHandler(IMediator mediator, IMapper mapper, IDefeitoRepositorio repository)
        {
            _repositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<DefeitoExcluirResposta>> Handle(DefeitoExcluir request, CancellationToken cancellationToken)
        {
            //Busca entidade no banco
            Dominio.Entidade.Defeito entidadeBD = _repositorio.ObterPorId(request.Id);

            //Atualiza dados com as informações da tela
            //_mapper.Map(request, entidadeBD);

            ////Valida os campos obrigatorio do mapeamento
            //ResultadoOperacao validador = entidadeBD.ValidaDados(entidadeBD);
            //if (validador.Sucesso == false)
            //{
            //    var erro = ConverterMensagem(validador, entidadeBD);
            //    return await Task.FromResult(erro);
            //}

            //Grava no bando de dados
            _repositorio.Deletar(entidadeBD);

            //Gera registro de historico na tabela de auditoria
            AuditoriaObjetoJson auditoriaObjetoJson = new AuditoriaObjetoJson();
            var objAuditoria = auditoriaObjetoJson.Criar(entidadeBD, entidadeBD.Id_Tenant, entidadeBD.Id, "Defeito", ModoCruds.Excluir);
            _mediator.Send(objAuditoria.Result);

            ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
            var sucesso = ConverterMensagem(resultadoOperacao, entidadeBD);
            return await Task.FromResult(sucesso);
        }

        public ResultadoOperacao<DefeitoExcluirResposta> ConverterMensagem(ResultadoOperacao resultado, Dominio.Entidade.Defeito entidadeBD)
        {
            var retorno = new ResultadoOperacao<DefeitoExcluirResposta>(new DefeitoExcluirResposta { Id = entidadeBD.Id });
            retorno.Sucesso = resultado.Sucesso;
            retorno.Mensagem = resultado.Mensagem;
            return retorno;
        }
    }

}