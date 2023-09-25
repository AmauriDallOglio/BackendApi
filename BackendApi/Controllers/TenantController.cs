using BackendApi.Aplicacao.Aplicacao.Defeito;
using BackendApi.Aplicacao.Aplicacao.Tenant;
using BackendApi.Dominio.Modelo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/v1/Tenant")]
    [ApiController]
    public class TenantController : ControllerBase
    {


        private readonly IMediator _mediator;

        public TenantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Conexao"), ActionName("Conexao")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public async Task<string> Conexao()
        {
            return "Ok";
        }


        [HttpPost("Inserir"), ActionName("Inserir")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public async Task<TenantInserirResponse> Inserir([FromBody] TenantInserirRequest dadosEntrada)
        {
            //try
            //{
            var response = _mediator.Send(dadosEntrada);
            //    if (response.Result.Sucesso == false)
            //    {
            //        return BadRequest(response.Result.Mensagem);
            //    }
              return response.Result.Modelo; // Ok(response.Result.Modelo.Id.ToString());
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
        }

        [HttpPut("Alterar"), ActionName("Alterar")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public Task<TenantAlterarResponse> Alterar([FromBody] TenantAlterarRequest dadosEntrada)
        {
            var response = _mediator.Send(dadosEntrada);
            return response;
        }

        [HttpDelete("Excluir"), ActionName("Excluir")]
        public Task<TenantExcluirResponse> Excluir([FromBody] TenantExcluirRequest dadosEntrada)
        {
            var response = _mediator.Send(dadosEntrada);
            return response;
        }


 

        [HttpGet("ListarTodos"), ActionName("ListarTodos")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public async Task<RetornoPaginadoGenerico<TenantListarTodosResponse>> ListarTodos([FromQuery] TenantListarTodosRequest dadosEntrada) //fromHead
        {
            Task<RetornoPaginadoGenerico<TenantListarTodosResponse>> response = _mediator.Send(dadosEntrada);
            return await response;
        }

        // Rota GET para obter uma lista de números
        [HttpGet("ListaNumeros")]
        public ActionResult<IEnumerable<int>> ListaNumeros()
        {
            List<int> numeros = new List<int> { 1, 2, 3, 4, 5 };
            return Ok(numeros);
        }

        [HttpGet("ListaNumeros2")]
        public ActionResult<RetornoPaginadoGenerico<IEnumerable<int>>> ListaNumeros2()
        {
            List<int> numeros = new List<int> { 1, 2, 3, 4, 5 };
            return Ok(numeros);
        }



        //[HttpGet("ListarTodos"), ActionName("ListarTodos")]
        //[ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        //public async Task<ActionResult<IEnumerable<TenantListarTodos.Response>>> ListarTodos([FromQuery] TenantListarTodos.Request dadosEntrada) //fromHead
        //{
        //    RetornoPaginadoGenerico<TenantListarTodos.Response> resultado = await _mediator.Send(dadosEntrada);
        //    var listaDeTenantListarTodosResponse = resultado.Modelos.ToList();
        //    return Ok(listaDeTenantListarTodosResponse);
        //}



        //[HttpGet("ListarTodos2")]
        //public async Task<IActionResult> ListarTodos2([FromQuery] TenantListarTodosRequest dadosEntrada)
        //{
        //    try
        //    {
        //        var resultado = await _mediator.Send(dadosEntrada);
        //        return Ok(resultado);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Erro: {ex.Message}");
        //    }
        //}


        [HttpGet("ConsultarPorId"), ActionName("ConsultarPorId")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public async Task<IActionResult> ConsultarPorId([FromQuery] TenantPorIdRequest dadosEntrada)
        {
            Task<TenantPorIdResponse> response = _mediator.Send(dadosEntrada);
            return Ok(await response);
        }



    }
}
