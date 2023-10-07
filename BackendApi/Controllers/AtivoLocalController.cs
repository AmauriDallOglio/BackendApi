using BackendApi.Aplicacao.Aplicacao.AtivoLocal.Command;
using BackendApi.Aplicacao.Aplicacao.AtivoLocal.Queries;
using BackendApi.Dominio.Modelo;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BackendApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/AtivoLocal")]
    [ApiController]
    public class AtivoLocalController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<AtivoLocalInserirCommand> _validador;
        private readonly IStringLocalizer<AtivoLocalController> _localizer;
        public AtivoLocalController(IMediator mediator, IValidator<AtivoLocalInserirCommand> validador, IStringLocalizer<AtivoLocalController> localizer)
        {
            _mediator = mediator;
            _validador = validador;
            _localizer = localizer;
        }

        [HttpGet("Conexao"), ActionName("Conexao")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public string Conexao()
        {
            return "Ok";
        }

 
 



        [HttpPost("Inserir"), ActionName("Inserir")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public async Task<IActionResult> Inserir([FromBody] AtivoLocalInserirCommand dadosEntrada)
        {
            var resultadoValidacao = _validador.Validate(dadosEntrada);

            if (!resultadoValidacao.IsValid)
            {
                var erros = resultadoValidacao.Errors.Select(x => _localizer[x.ErrorMessage]);
                return BadRequest(erros);
            }

            var response = await _mediator.Send(dadosEntrada);
            return Ok(response);
        }
 

        [HttpPut("Alterar"), ActionName("Alterar")]
        public async Task<IActionResult> Alterar([FromBody] AtivoLocalAlterarCommand dadosEntrada)
        {
            var response = await _mediator.Send(dadosEntrada);
            if (response.Sucesso == false)
            {
                BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("Excluir"), ActionName("Excluir")]
        public async Task<IActionResult> Excluir([FromBody] AtivoLocalExcluirCommand dadosEntrada)
        {
            var response = await _mediator.Send(dadosEntrada);
            return Ok(response);
        }



        [HttpGet("ListarTodos"), ActionName("ListarTodos")]
        public async Task<ActionResult<IEnumerable<AtivoLocalListarTodosResponseQueries>>> ListarTodos([FromQuery] AtivoLocalListarTodosQueries dadosEntrada) 
        {
            RetornoPaginadoGenerico<AtivoLocalListarTodosResponseQueries> resultado = await _mediator.Send(dadosEntrada);
            var lista = resultado.Modelos.ToList();
            return Ok(lista);
        }

    }
}
