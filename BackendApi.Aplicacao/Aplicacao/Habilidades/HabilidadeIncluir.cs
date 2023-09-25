using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Util;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Habilidades
{
    public class HabilidadeIncluir : IRequest<ResultadoOperacao<RespostaHabilidade>>
    {
        public Guid Id_Tenant { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }

    public class RespostaHabilidade
    { 
        public Guid Id { get; set; }

    }

    internal class HabilidadeInserirHandler : IRequestHandler<HabilidadeIncluir, ResultadoOperacao<RespostaHabilidade>>
    {
        private readonly IHabilidadeRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public HabilidadeInserirHandler(IMediator mediator, IMapper mapper, IHabilidadeRepositorio repository)
        {
            _repositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<RespostaHabilidade>> Handle(HabilidadeIncluir request, CancellationToken cancellationToken)
        {
            ResultadoOperacao<RespostaHabilidade> resultadoOperacao = new ResultadoOperacao<RespostaHabilidade>(null)
            {
                Sucesso = true,
                Mensagem = ""
            };

            var entidade = _mapper.Map<Dominio.Entidade.Habilidade>(request);
            entidade = entidade.DadosDoIncluir();

            //Valida os campos obrigatorio do mapeamento
            var validador = entidade.ValidaDados(entidade);
            if (validador.Sucesso == false)
            {
                var resposta = new RespostaHabilidade
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
            var objAuditoria = auditoriaObjetoJson.Criar(entidadeBD, entidadeBD.Id_Tenant, entidadeBD.Id, "Habilidade", ModoCruds.Inserir);
            _mediator.Send(objAuditoria.Result);


            var respostas = new RespostaHabilidade
            {
                Id = entidadeBD.Id
            };
            resultadoOperacao.Modelo = respostas;

            return Task.FromResult(resultadoOperacao);
        }
    }



}
