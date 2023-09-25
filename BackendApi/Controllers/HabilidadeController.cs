using BackendApi.Aplicacao.Aplicacao.AtivoTipo;
using BackendApi.Aplicacao.Aplicacao.Habilidades;
using BackendApi.Dominio.Modelo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/v1/Habilidade")]
    [ApiController]
    public class HabilidadeController : Controller
    {
        private readonly IMediator _mediator;
        public HabilidadeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Conexao"), ActionName("Conexao")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public string Conexao()
        {
            return "Ok";
        }

        [HttpPost("Incluir"), ActionName("Incluir")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public async Task<ResultadoOperacao<RespostaHabilidade>> Incluir([FromBody] HabilidadeIncluir dadosEntrada)
        {
            var response = await _mediator.Send(dadosEntrada);
            return response;
        }



    }
}
