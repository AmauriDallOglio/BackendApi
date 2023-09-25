using BackendApi.Dominio.Modelo;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Defeito
{
    public class DefeitoListarTodosRequest : IRequest<RetornoPaginadoGenerico<DefeitoListarTodosResponse>>
    {
        public string? Descricao { get; set; }
    }
}
