using BackendApi.Aplicacao.Aplicacao.AtivoLocal.Command;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BackendApi.Aplicacao.Validador
{
    public class AtivoLocalInserirValidador : AbstractValidator<AtivoLocalInserirCommand>
    {
        public AtivoLocalInserirValidador(IStringLocalizer<AtivoLocalInserirValidador> localizer)
        {
            RuleFor(request => request.Referencia)
                .NotEmpty().WithMessage(x => localizer["Referencia é obrigatória!"]);
            RuleFor(request => request.Descricao)
                .NotEmpty().WithMessage(x => localizer["Descrição é obrigatória!"]);
        }
    }
     
}