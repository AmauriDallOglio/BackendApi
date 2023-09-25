using BackendApi.Aplicacao.Aplicacao.CheckListTipo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/v1/CheckListTipo")]
    [ApiController]
    public class CheckListTipoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CheckListTipoController(IMediator mediator)
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
        public async Task<CheckListTipoInserirResponse> Inserir([FromBody] CheckListTipoInserirRequest dadosEntrada)
        {
            var response = _mediator.Send(dadosEntrada);
            return response.Result.Modelo; 
        }

        [HttpPut("Alterar"), ActionName("Alterar")]
        public Task<Guid> Alterar([FromQuery] CheckListTipoAlterar dadosEntrada)
        {
            var response = _mediator.Send(dadosEntrada);
            return response;
        }

    }
}
