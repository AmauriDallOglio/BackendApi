using AutoMapper;
using BackendApi.Aplicacao.Interface;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using BackendApi.Dominio.Validador;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Defeito
{
    public class DefeitoIncluirHandler : IRequestHandler<DefeitoIncluir.Request, ResultadoOperacao<DefeitoIncluir.DefeitoIncluirResponse>>, IDefeitoInserirAplicacao
    {
        private readonly IDefeitoRepositorio _iDefeitoRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DefeitoIncluirHandler(IMediator mediator, IMapper mapper, IDefeitoRepositorio repository)
        {
            _iDefeitoRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<DefeitoIncluir.DefeitoIncluirResponse>> Handle(DefeitoIncluir.Request request, CancellationToken cancellationToken)
        {
            var resultadoOperacao = CriarResultadoOperacao();
            var entidade = _mapper.Map<Dominio.Entidade.Defeito>(request);

            var validador = ValidaMapeamento(entidade);
            if (validador.Sucesso == false)
            {
                resultadoOperacao.Sucesso = validador.Sucesso;
                resultadoOperacao.Mensagem = validador.Mensagem;
                return Task.FromResult(resultadoOperacao);
            }

            var entidadeBD = _iDefeitoRepositorio.Inserir(entidade, true);
            var dto = _mapper.Map<DefeitoIncluir.DefeitoIncluirResponse>(entidadeBD);
            resultadoOperacao.Modelo = dto;

            //InserirAuditoria(dto.Id, dto.Id);

            return Task.FromResult(resultadoOperacao);
        }

        //public async Task InserirAuditoria(Guid idTenante, Guid idRegistroAtual)
        //{
        //    AuditoriaInserirRequest auditoria = new AuditoriaInserirRequest { IdTenant = idTenante, IdRegistro = idRegistroAtual, NomeTabela = "Defeito", ModoCrud = (short)ModoCruds.Inserir };
        //    _mediator.Send(auditoria);
        //}

        public ResultadoOperacao<DefeitoIncluir.DefeitoIncluirResponse> CriarResultadoOperacao()
        {
            ResultadoOperacao<DefeitoIncluir.DefeitoIncluirResponse> resultadoOperacao = new ResultadoOperacao<DefeitoIncluir.DefeitoIncluirResponse>(null)
            {
                Sucesso = true,
                Mensagem = ""
            };
            return resultadoOperacao;
        }
        public ResultadoOperacao<Dominio.Entidade.Defeito> ValidaMapeamento(Dominio.Entidade.Defeito entidade)
        {
            ResultadoOperacao<Dominio.Entidade.Defeito> validador = new DefeitoValidador().Validar(entidade);
            return validador;
        }
    }
}
