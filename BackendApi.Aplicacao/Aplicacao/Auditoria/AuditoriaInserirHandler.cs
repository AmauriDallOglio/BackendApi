using AutoMapper;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Util;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Auditoria
{
    public class AuditoriaInserirHandler : IRequestHandler<AuditoriaInserirRequest, AuditoriaInserirResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IAuditoriaRepositorio _iAuditoriaRepositorio;

        public AuditoriaInserirHandler(IAuditoriaRepositorio iAuditoriaRepositorio, IMediator mediator, IMapper mapper)
        {
            _iAuditoriaRepositorio = iAuditoriaRepositorio; 

            _mediator = mediator;
            _mapper = mapper;
        }

        public Task<AuditoriaInserirResponse> Handle(AuditoriaInserirRequest request, CancellationToken cancellationToken)
        {
            var entidade = _mapper.Map<Dominio.Entidade.Auditoria>(request);
            switch (request.ModoCrud)
            {
                case (short)ModoCruds.Inserir:
                    entidade.DadosDoIncluir(request.IdTenant, request.IdRegistro, request.NomeTabela, request.Json);
                    break;
                case (short)ModoCruds.Alterar:
                    entidade.DadosDoAlterar(request.IdTenant, request.IdRegistro, request.NomeTabela, request.Json);
                    break;
                case (short)ModoCruds.Excluir:
                    entidade.DadosDoExcluir(request.IdTenant, request.IdRegistro, request.NomeTabela, request.Json);
                    break;
            }
            var auditoriaBD = _iAuditoriaRepositorio.Inserir(entidade, true);
            AuditoriaInserirResponse dto = _mapper.Map<AuditoriaInserirResponse>(auditoriaBD);
            return Task.FromResult(dto);
        }
    }
}