using BackendApi.Aplicacao.Aplicacao.AtivoTipo;
using BackendApi.Dominio.Modelo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/AtivoTipo")]

    [ApiController]
    public class AtivoTipoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AtivoTipoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Conexao"), ActionName("Conexao")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public string Conexao()
        {
            return "Ok";
        }


        [HttpPost("Inserir"), ActionName("Inserir")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public async Task<ResultadoOperacao<Resposta>> Inserir([FromBody] AtivoTipoInserir dadosEntrada)
        {
          
            var response = await _mediator.Send(dadosEntrada);
            return response;
        }

        [HttpPut("Alterar"), ActionName("Alterar")]
        public async Task<IActionResult> Alterar([FromBody] AtivoTipoAlterar dadosEntrada)
        {
            var response = await _mediator.Send(dadosEntrada);
            if (response.Sucesso == false)
            {
                BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("Excluir"), ActionName("Excluir")]
        public async Task<IActionResult> Excluir([FromBody] AtivoTipoExcluir dadosEntrada)
        {
            var response = await _mediator.Send(dadosEntrada);
            return Ok(response);
        }


        [HttpGet("ListarTodos"), ActionName("ListarTodos")]
        public async Task<ActionResult<IEnumerable<AtivoTipoListarTodosResponse>>> ListarTodos([FromQuery] AtivoTipoListarTodos dadosEntrada) //fromHead
        {
            RetornoPaginadoGenerico<AtivoTipoListarTodosResponse> resultado = await _mediator.Send(dadosEntrada);
            var lista = resultado.Modelos.ToList();
            return Ok(lista);
        }


    }
}
