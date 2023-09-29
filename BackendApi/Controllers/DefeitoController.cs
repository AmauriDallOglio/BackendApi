using BackendApi.Aplicacao.Aplicacao.Defeito;
using BackendApi.Dominio.Modelo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static BackendApi.Aplicacao.Aplicacao.Defeito.DefeitoIncluir;

namespace BackendApi.Controllers
{
    [Route("api/v1/Defeito")]
    [ApiController]
    public class DefeitoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DefeitoController(IMediator mediator)
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
        public async Task<ResultadoOperacao<DefeitoIncluirResponse>> Inserir([FromBody] DefeitoIncluir.Request dadosEntrada)
        {
            var response = await _mediator.Send(dadosEntrada);
            return response;
        }

        [HttpPut("Alterar"), ActionName("Alterar")]
        public Task<DefeitoAlterar.Response> Alterar([FromQuery] DefeitoAlterar.Request dadosEntrada)
        {
            var response = _mediator.Send(dadosEntrada);
            return response;
        }

        [HttpDelete("Excluir"), ActionName("Excluir")]
        public async Task<IActionResult> Excluir([FromBody] DefeitoExcluir dadosEntrada)
        {
            var response = await _mediator.Send(dadosEntrada);
            return Ok(response);
        }


        [HttpGet("ListarTodos"), ActionName("ListarTodos")]
        public async Task<ActionResult<IEnumerable<DefeitoListarTodosResponse>>> ListarTodos([FromQuery] DefeitoListarTodosRequest dadosEntrada) //fromHead
        {
            RetornoPaginadoGenerico<DefeitoListarTodosResponse> resultado = await _mediator.Send(dadosEntrada);
            var lista = resultado.Modelos.ToList();
            return Ok(lista);
        }
    }
}
