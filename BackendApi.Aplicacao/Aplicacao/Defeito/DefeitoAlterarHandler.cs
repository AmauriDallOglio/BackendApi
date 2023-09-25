using AutoMapper;
using BackendApi.Aplicacao.Aplicacao.Auditoria;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Util;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Defeito
{
    public class DefeitoAlterarHandler : IRequestHandler<DefeitoAlterar.Request, DefeitoAlterar.Response>
    {
        private readonly IDefeitoRepositorio _iDefeitoRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DefeitoAlterarHandler(IMediator mediator, IMapper mapper, IDefeitoRepositorio repository)
        {
            _iDefeitoRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<DefeitoAlterar.Response> Handle(DefeitoAlterar.Request request, CancellationToken cancellationToken)
        {
            var entidadeMapeada = _mapper.Map<Dominio.Entidade.Defeito>(request);
            var defeitoBanco = _iDefeitoRepositorio.ObterPorId(request.Id);
            defeitoBanco.Descricao = request.Descricao;
            defeitoBanco.Referencia = request.Referencia;
            Dominio.Entidade.Defeito defeito = _iDefeitoRepositorio.Alterar(defeitoBanco, true);
          //  InserirLogAuditoria(defeito.Id, defeito.Id);
            var resultado = _mapper.Map<DefeitoAlterar.Response>(defeito);
            return await Task.FromResult(resultado);
        }

        //private async Task InserirLogAuditoria(Guid idTenante, Guid idRegistroAtual)
        //{
        //    AuditoriaInserirRequest auditoria = new AuditoriaInserirRequest { IdTenant = idTenante, IdRegistro = idRegistroAtual, NomeTabela = "Defeito", ModoCrud = (short)ModoCruds.Alterar };
        //    await _mediator.Send(auditoria);
        //}


    }
}
