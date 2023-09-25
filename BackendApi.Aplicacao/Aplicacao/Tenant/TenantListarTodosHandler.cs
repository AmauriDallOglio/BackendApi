using AutoMapper;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Tenant
{
    public class TenantListarTodosHandler : IRequestHandler<TenantListarTodosRequest, RetornoPaginadoGenerico<TenantListarTodosResponse>>
    {
        private readonly ITenantRepositorio _iTenantRepositorio;
        private readonly IMapper _mapper;

        public TenantListarTodosHandler(ITenantRepositorio repository, IMapper mapper)
        {
            _iTenantRepositorio = repository;
            _mapper = mapper;
        }

        public async Task<RetornoPaginadoGenerico<TenantListarTodosResponse>> Handle(TenantListarTodosRequest request, CancellationToken cancellationToken) //Task<IEnumerable<ConsultaTenantListaTodosResponse>> Handle(ConsultaTenantListaTodosRequest request, CancellationToken cancellationToken)
        {
            var listaTenant = _iTenantRepositorio.BuscarTodosPorDescricao(request.Descricao);
            var listaDto = _mapper.Map<List<TenantListarTodosResponse>>(listaTenant);
            RetornoPaginadoGenerico<TenantListarTodosResponse> retornoPaginado = new RetornoPaginadoGenerico<TenantListarTodosResponse>
            {
                Modelos = listaDto,
                ItemPorPagina = 1,
                Pagina = 10,
                TotalRegistros = listaDto.Count()
            };
            return await Task.FromResult(retornoPaginado);
        }
    }
}

