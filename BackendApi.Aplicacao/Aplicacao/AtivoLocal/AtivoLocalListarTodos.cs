using AutoMapper;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.AtivoLocal
{
    public class AtivoLocalListarTodos : IRequest<RetornoPaginadoGenerico<AtivoLocalListarTodosResponse>>
    {
        public string? Descricao { get; set; }
    }

    public class AtivoLocalListarTodosResponse : Dominio.Entidade.AtivoLocal
    {

    }

    public class AtivoLocalListarTodosHandler : IRequestHandler<AtivoLocalListarTodos, RetornoPaginadoGenerico<AtivoLocalListarTodosResponse>>
    {
        private readonly IAtivoLocalRepositorio _repositorio;
        private readonly IMapper _mapper;

        public AtivoLocalListarTodosHandler(IAtivoLocalRepositorio repository, IMapper mapper)
        {
            _repositorio = repository;
            _mapper = mapper;
        }

        public async Task<RetornoPaginadoGenerico<AtivoLocalListarTodosResponse>> Handle(AtivoLocalListarTodos request, CancellationToken cancellationToken)
        {
            List<Dominio.Entidade.AtivoLocal> lista = _repositorio.BuscarTodosPorDescricao(request.Descricao);
            var listaDto = _mapper.Map<List<AtivoLocalListarTodosResponse>>(lista);
            RetornoPaginadoGenerico<AtivoLocalListarTodosResponse> retornoPaginado = new RetornoPaginadoGenerico<AtivoLocalListarTodosResponse>
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
