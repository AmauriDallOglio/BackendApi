using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.Modelo;
using FluentValidation;

namespace BackendApi.Dominio.Validador
{
    public class AtivoTipoValidador : AbstractValidator<AtivoTipo>
    {
        public AtivoTipoValidador()
        {
            RuleFor(x => x.Referencia).NotEmpty().WithMessage("O valor de Referencia é inválido");
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("O valor de Descricao é inválido");
        }

        public ResultadoOperacao Validar(AtivoTipo entidade)
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
