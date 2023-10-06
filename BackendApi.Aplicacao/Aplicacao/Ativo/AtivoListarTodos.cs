using AutoMapper;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Dominio.Modelo;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Ativo
{
    public class AtivoListarTodos : IRequest<RetornoPaginadoGenerico<AtivoListarTodosResponse>>
    {
        public string? Descricao { get; set; }
    }

    public class AtivoListarTodosResponse : Dominio.Entidade.Ativo
    {


         


    }


    public class AtivoListarTodosHandler : IRequestHandler<AtivoListarTodos, RetornoPaginadoGenerico<AtivoListarTodosResponse>>
    {
        private readonly IAtivoRepositorio _repositorio;
        private readonly IMapper _mapper;

        public AtivoListarTodosHandler(IAtivoRepositorio repository, IMapper mapper)
        {
            _repositorio = repository;
            _mapper = mapper;
        }

        public async Task<RetornoPaginadoGenerico<AtivoListarTodosResponse>> Handle(AtivoListarTodos request, CancellationToken cancellationToken)
        {
            List<Dominio.Entidade.Ativo> lista = _repositorio.BuscarTodosPorDescricao(request.Descricao);
            var listaDto = _mapper.Map<List<AtivoListarTodosResponse>>(lista);
            RetornoPaginadoGenerico<AtivoListarTodosResponse> retornoPaginado = new RetornoPaginadoGenerico<AtivoListarTodosResponse>
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
