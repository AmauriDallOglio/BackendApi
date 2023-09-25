using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.Modelo;
using FluentValidation;

namespace BackendApi.Dominio.Validador
{
    public class TenantValidador : AbstractValidator<Tenant>
    {
        public TenantValidador()
        {
            RuleFor(x => x.Referencia).NotEmpty().WithMessage("O valor de Referencia é inválido");
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("O valor de Descricao é inválido");
        }

        public ResultadoOperacao<Tenant> Validar(Tenant entidade)
        {
            var resultado = new ResultadoOperacao<Tenant>(entidade);
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
