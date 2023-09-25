using BackendApi.Aplicacao.Aplicacao.Ativo;
using BackendApi.Aplicacao.Aplicacao.AtivoLocal;
using BackendApi.Dominio.Modelo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Ativo")]
    [ApiController]
    public class AtivoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AtivoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Conexao"), ActionName("Conexao")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public string Conexao()
        {
            return "Ok";
        }


        [HttpGet("ListarTodos"), ActionName("ListarTodos")]
        public async Task<ActionResult<IEnumerable<AtivoListarTodosResponse>>> ListarTodos([FromQuery] AtivoListarTodos dadosEntrada)
        {
            RetornoPaginadoGenerico<AtivoListarTodosResponse> resultado = await _mediator.Send(dadosEntrada);
            var lista = resultado.Modelos.ToList();
            return Ok(lista);
        }



    }
}
