using BackendApi.Dominio.Modelo;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Defeito
{
    public class DefeitoListarTodos
    {
        public class Request : IRequest<RetornoPaginadoGenerico<Response>>
        {
            public string? Descricao { get; set; }
        }

        public class Response : Dominio.Entidade.Defeito
        {

        }
    }
}
