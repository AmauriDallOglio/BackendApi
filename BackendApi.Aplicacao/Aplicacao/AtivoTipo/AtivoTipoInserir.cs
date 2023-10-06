using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Util;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.AtivoTipo
{
    public class AtivoTipoInserir : IRequest<ResultadoOperacao<Resposta>>
    {
        public Guid Id_Tenant { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }

    public class Resposta 
    {
        public Guid Id { get; set; }
  
    }


    internal class AtivoTipoInserirHandler : IRequestHandler<AtivoTipoInserir, ResultadoOperacao<Resposta>>
    {
        private readonly IAtivoTipoRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AtivoTipoInserirHandler(IMediator mediator, IMapper mapper, IAtivoTipoRepositorio repository)
        {
            _repositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<Resposta>> Handle(AtivoTipoInserir request, CancellationToken cancellationToken)
        {
            ResultadoOperacao<Resposta> resultadoOperacao = new ResultadoOperacao<Resposta>(null)
            {
                Sucesso = true,
                Mensagem = ""
            };
 
            var entidade = _mapper.Map<Dominio.Entidade.AtivoTipo>(request);
            entidade = entidade.DadosDoIncluir();

            //Valida os campos obrigatorio do mapeamento
            var validador = entidade.ValidaDados(entidade);
            if (validador.Sucesso == false)
            {
                var resposta = new Resposta
                {
                    Id = request.Id_Tenant
                };

                resultadoOperacao.Sucesso = false;
                resultadoOperacao.Mensagem = validador.Mensagem;
                resultadoOperacao.Modelo = resposta;
                return Task.FromResult(resultadoOperacao);
            }

            //Grava no bando de dados
            var entidadeBD = _repositorio.Inserir(entidade, true);

            
            AuditoriaObjetoJson auditoriaObjetoJson = new AuditoriaObjetoJson();
            var objAuditoria = auditoriaObjetoJson.Criar(entidadeBD, entidadeBD.Id_Tenant, entidadeBD.Id, "AtivoTipo", ModoCruds.Inserir);
            _mediator.Send(objAuditoria.Result);


            var respostas = new Resposta
            {
                Id = entidadeBD.Id
            };
            resultadoOperacao.Modelo = respostas;

            return Task.FromResult(resultadoOperacao);
        }
    }
}
