using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Util;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.AtivoTipo
{
    public class AtivoTipoAlterar : IRequest<ResultadoOperacao<RespostaAlterar>>
    {
        public Guid Id { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }

    public class RespostaAlterar
    {
        public Guid Id { get; set; }

    }

    internal class AtivoTipoAlterarHandler : IRequestHandler<AtivoTipoAlterar, ResultadoOperacao<RespostaAlterar>>
    {
        private readonly IAtivoTipoRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AtivoTipoAlterarHandler(IMediator mediator, IMapper mapper, IAtivoTipoRepositorio repository)
        {
            _repositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<RespostaAlterar>> Handle(AtivoTipoAlterar request, CancellationToken cancellationToken)
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
            _repositorio.Alterar(entidadeBD, true);

            //Gera registro de historico na tabela de auditoria
            AuditoriaObjetoJson auditoriaObjetoJson = new AuditoriaObjetoJson();
            var objAuditoria = auditoriaObjetoJson.Criar(entidadeBD, entidadeBD.Id_Tenant, entidadeBD.Id, "AtivoTipo", ModoCruds.Alterar);
            _mediator.Send(objAuditoria.Result);

            var sucesso = ConverterMensagem(validador, entidadeBD);
            return await Task.FromResult(sucesso);
        }

        public ResultadoOperacao<RespostaAlterar> ConverterMensagem(ResultadoOperacao resultado, Dominio.Entidade.AtivoTipo entidadeBD)
        {
            var retorno = new ResultadoOperacao<RespostaAlterar>(new RespostaAlterar { Id = entidadeBD.Id });
            retorno.Sucesso = resultado.Sucesso;
            retorno.Mensagem = resultado.Mensagem;
            return retorno;
        }
    }
}
