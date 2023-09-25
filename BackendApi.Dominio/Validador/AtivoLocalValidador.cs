using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.Modelo;
using FluentValidation;

namespace BackendApi.Dominio.Validador
{
    public class AtivoLocalValidador : AbstractValidator<AtivoLocal>
    {
        public AtivoLocalValidador()
        {
            RuleFor(x => x.Referencia).NotEmpty().WithMessage("O valor de Referencia é inválido");
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("O valor de Descricao é inválido");
        }

        public ResultadoOperacao Validar(AtivoLocal entidade)
        {
            var resultado = new ResultadoOperacao();
            var validacao = Validate(entidade);
            if (!validacao.IsValid)
            {
                resultado.Sucesso = false;
                foreach (var erro in validacao.Errors)
                {
                    resultado.Mensagem += erro.PropertyName + " : " + erro.ErrorMessage + "  ";
                }
            }
            return resultado;
        }

    }
}
