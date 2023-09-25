using AutoMapper;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.AtivoTipo
{
    public class AtivoTipoListarTodos : IRequest<RetornoPaginadoGenerico<AtivoTipoListarTodosResponse>>
    {
        public string? Descricao { get; set; }
    }

    public class AtivoTipoListarTodosResponse : Dominio.Entidade.AtivoTipo
    {

    }

    public class AtivoTipoListarTodosHandler : IRequestHandler<AtivoTipoListarTodos, RetornoPaginadoGenerico<AtivoTipoListarTodosResponse>>
    {
        private readonly IAtivoTipoRepositorio _repositorio;
        private readonly IMapper _mapper;

        public AtivoTipoListarTodosHandler(IAtivoTipoRepositorio repository, IMapper mapper)
        {
            _repositorio = repository;
            _mapper = mapper;
        }

        public async Task<RetornoPaginadoGenerico<AtivoTipoListarTodosResponse>> Handle(AtivoTipoListarTodos request, CancellationToken cancellationToken)
        {
            List<Dominio.Entidade.AtivoTipo> lista = _repositorio.BuscarTodosPorDescricao(request.Descricao);
            var listaDto = _mapper.Map<List<AtivoTipoListarTodosResponse>>(lista);
            RetornoPaginadoGenerico<AtivoTipoListarTodosResponse> retornoPaginado = new RetornoPaginadoGenerico<AtivoTipoListarTodosResponse>
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
