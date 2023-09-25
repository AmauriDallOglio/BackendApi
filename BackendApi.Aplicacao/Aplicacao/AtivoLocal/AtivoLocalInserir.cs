using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Util;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.AtivoLocal
{
    public class AtivoLocalInserir : IRequest<ResultadoOperacao<AtivoLocalInserirResposta>>
    {
        public Guid Id_Tenant { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty; 
        public string Setor { get; set; } = string.Empty;

    }

    public class AtivoLocalInserirResposta
    {
        public Guid Id { get; set; }
    }


    internal class AtivoLocalInserirHandler : IRequestHandler<AtivoLocalInserir, ResultadoOperacao<AtivoLocalInserirResposta>>
    {
        private readonly IAtivoLocalRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AtivoLocalInserirHandler(IMediator mediator, IMapper mapper, IAtivoLocalRepositorio repository)
        {
            _repositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<AtivoLocalInserirResposta>> Handle(AtivoLocalInserir request, CancellationToken cancellationToken)
        {
            ResultadoOperacao<AtivoLocalInserirResposta> resultadoOperacao = new ResultadoOperacao<AtivoLocalInserirResposta>(null)
            {
                Sucesso = true,
                Mensagem = ""
            };

            var entidade = _mapper.Map<Dominio.Entidade.AtivoLocal>(request);
            entidade = entidade.DadosDoIncluir();

            //Valida os campos obrigatorio do mapeamento
            var validador = entidade.ValidaDados(entidade);
            if (validador.Sucesso == false)
            {
                var resposta = new AtivoLocalInserirResposta
                {
                    Id = Guid.Parse("0")
                };

                resultadoOperacao.Sucesso = false;
                resultadoOperacao.Mensagem = validador.Mensagem;
                resultadoOperacao.Modelo = resposta;
                return Task.FromResult(resultadoOperacao);
            }

            //Grava no bando de dados
            var entidadeBD = _repositorio.Inserir(entidade, true);


            AuditoriaObjetoJson auditoriaObjetoJson = new AuditoriaObjetoJson();
            var objAuditoria = auditoriaObjetoJson.Criar(entidadeBD, entidadeBD.Id_Tenant, entidadeBD.Id, "AtivoLocal", ModoCruds.Inserir);
            _mediator.Send(objAuditoria.Result);


            var respostas = new AtivoLocalInserirResposta
            {
                Id = entidadeBD.Id
            };
            resultadoOperacao.Modelo = respostas;

            return Task.FromResult(resultadoOperacao);
        }
    }
}
