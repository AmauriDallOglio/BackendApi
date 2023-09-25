using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    public class EmpresaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmpresaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Ok"), ActionName("Ok")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public string Ok()
        {
            return "Sucesso";
        }

      
    }
}

