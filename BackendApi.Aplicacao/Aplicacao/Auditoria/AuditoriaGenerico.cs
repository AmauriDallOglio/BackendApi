using AutoMapper;
using BackendApi.Dominio.InterfaceRepositorio;
using MediatR;

namespace BackendApi.Aplicacao.Aplicacao.Auditoria
{
    public class AuditoriaGenerico<T> : IRequest<string>
    {
        public T Dados { get; set; }
    }

    internal class AuditoriaGenericoHandler<T> : IRequestHandler<AuditoriaGenerico<T>, string>
    {
        //private readonly IMapper _mapper;
        //private readonly IMediator _mediator;
        //private readonly IAuditoriaRepositorio _iAuditoriaRepositorio;

        //public AuditoriaGenericoHandler(IAuditoriaRepositorio iAuditoriaRepositorio, IMediator mediator, IMapper mapper)
        //{
        //    _iAuditoriaRepositorio = iAuditoriaRepositorio;

        //    _mediator = mediator;
        //    _mapper = mapper;
        //}

        public Task<string> Handle(AuditoriaGenerico<T> request, CancellationToken cancellationToken)
        {
 
            return Task.FromResult("ok");
        }
    }

}
