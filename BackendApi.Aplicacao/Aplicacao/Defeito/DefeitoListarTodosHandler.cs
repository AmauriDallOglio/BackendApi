using AutoMapper;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Defeito
{
    public class DefeitoListarTodosHandler : IRequestHandler<DefeitoListarTodosRequest, RetornoPaginadoGenerico<DefeitoListarTodosResponse>>
    {
        private readonly IDefeitoRepositorio _iDefeitoRepositorio;
        private readonly IMapper _mapper;

        public DefeitoListarTodosHandler(IDefeitoRepositorio repository, IMapper mapper)
        {
            _iDefeitoRepositorio = repository;
            _mapper = mapper;
        }

        public async Task<RetornoPaginadoGenerico<DefeitoListarTodosResponse>> Handle(DefeitoListarTodosRequest request, CancellationToken cancellationToken)
        {
            var lista = _iDefeitoRepositorio.BuscarTodosPorDescricao(request.Descricao);
            var listaDto = _mapper.Map<List<DefeitoListarTodosResponse>>(lista);
            RetornoPaginadoGenerico<DefeitoListarTodosResponse> retornoPaginado = new RetornoPaginadoGenerico<DefeitoListarTodosResponse>
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
