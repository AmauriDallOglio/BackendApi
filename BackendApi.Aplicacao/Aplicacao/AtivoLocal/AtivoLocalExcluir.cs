using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Util;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.AtivoLocal
{
    public class AtivoLocalExcluir : IRequest<ResultadoOperacao<AtivoLocalExcluirResposta>>
    {

        public Guid Id { get; set; }

    }

    public class AtivoLocalExcluirResposta
    {
        public Guid Id { get; set; }

    }

    internal class AtivoLocalExcluirHandler : IRequestHandler<AtivoLocalExcluir, ResultadoOperacao<AtivoLocalExcluirResposta>>
    {
        private readonly IAtivoLocalRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AtivoLocalExcluirHandler(IMediator mediator, IMapper mapper, IAtivoLocalRepositorio repository)
        {
            _repositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<AtivoLocalExcluirResposta>> Handle(AtivoLocalExcluir request, CancellationToken cancellationToken)
        {
            //Busca entidade no banco
            Dominio.Entidade.AtivoLocal entidadeBD = _repositorio.ObterPorId(request.Id);
            //Grava no bando de dados
            _repositorio.Deletar(entidadeBD);
            //Gera registro de historico na tabela de auditoria
            AuditoriaObjetoJson auditoriaObjetoJson = new AuditoriaObjetoJson();
            var objAuditoria = auditoriaObjetoJson.Criar(entidadeBD, entidadeBD.Id_Tenant, entidadeBD.Id, "AtivoLocal", ModoCruds.Excluir);
            _mediator.Send(objAuditoria.Result);

            ResultadoOperacao<AtivoLocalExcluirResposta> resultadoOperacao = new ResultadoOperacao<AtivoLocalExcluirResposta>(null)
            {
                Sucesso = true,
                Mensagem = "Sucesso",
                Modelo = new AtivoLocalExcluirResposta
                {
                    Id = entidadeBD.Id
                }
            };
            return await Task.FromResult(resultadoOperacao);
        }

    }

}
