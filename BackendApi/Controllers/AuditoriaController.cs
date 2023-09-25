using BackendApi.Aplicacao.Aplicacao.Auditoria;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/v1/Auditoria")]
    [ApiController]
    public class AuditoriaController : ControllerBase
    {
        [HttpPost]
        [Route("Inserir")]
        public Task<AuditoriaInserirResponse> Inserir([FromServices] IMediator mediator, [FromBody] AuditoriaInserirRequest dadosEntrada)
        {
            var response = mediator.Send(dadosEntrada);
            return response;
        }

        [HttpPost]
        [Route("InserirGenerico")]
        public async Task<string> InserirGenerico<T>([FromServices] IMediator mediator, [FromBody] AuditoriaGenerico<string> dadosEntrada)
        {
            var response = await mediator.Send(new AuditoriaGenerico<string> { Dados = dadosEntrada.Dados });
            return response;
        }

    }
}
