using AutoMapper;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.AtivoLocal.Queries
{
    public class AtivoLocalListarTodosQueries : IRequest<RetornoPaginadoGenerico<AtivoLocalListarTodosResponseQueries>>
    {
        public string? Descricao { get; set; }
    }

    public class AtivoLocalListarTodosResponseQueries : Dominio.Entidade.AtivoLocal
    {

    }

    public class AtivoLocalListarTodosHandler : IRequestHandler<AtivoLocalListarTodosQueries, RetornoPaginadoGenerico<AtivoLocalListarTodosResponseQueries>>
    {
        private readonly IAtivoLocalRepositorio _repositorio;
        private readonly IMapper _mapper;

        public AtivoLocalListarTodosHandler(IAtivoLocalRepositorio repository, IMapper mapper)
        {
            _repositorio = repository;
            _mapper = mapper;
        }

        public async Task<RetornoPaginadoGenerico<AtivoLocalListarTodosResponseQueries>> Handle(AtivoLocalListarTodosQueries request, CancellationToken cancellationToken)
        {
            List<Dominio.Entidade.AtivoLocal> lista = _repositorio.BuscarTodosPorDescricao(request.Descricao);
            var listaDto = _mapper.Map<List<AtivoLocalListarTodosResponseQueries>>(lista);
            RetornoPaginadoGenerico<AtivoLocalListarTodosResponseQueries> retornoPaginado = new RetornoPaginadoGenerico<AtivoLocalListarTodosResponseQueries>
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
