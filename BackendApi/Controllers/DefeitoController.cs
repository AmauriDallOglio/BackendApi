using BackendApi.Aplicacao.Aplicacao.Defeito;
using BackendApi.Dominio.Modelo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("Ok"), ActionName("Ok")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public string Ok()
        {
            return "Blzz";
        }


        [HttpPost("Inserir"), ActionName("Inserir")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public async Task<IActionResult> Inserir([FromBody] DefeitoIncluir.Request dadosEntrada)
        {
            try
            {
                Guid tenantId = Guid.Parse("A31CF8A0-7B4D-EE11-A89E-F0D41578B814");
                dadosEntrada.Id_Tenant = tenantId;
                var response = _mediator.Send(dadosEntrada);
                if (response.Result.Modelo.Id == null)
                {
                    return BadRequest(response.Result);
                }
                return Ok(response.Result.Modelo.Id.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Alterar"), ActionName("Alterar")]
        public Task<DefeitoAlterar.Response> Alterar([FromQuery] DefeitoAlterar.Request dadosEntrada)
        {
            var response = _mediator.Send(dadosEntrada);
            return response;
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
