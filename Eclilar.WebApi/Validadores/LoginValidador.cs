using Eclilar.Infraestrutura.Seguranca.Models;
using FluentValidation;

namespace Eclilar.WebApi.Validadores
{
    public class LoginValidador : AbstractValidator<LoginRequest>
    {
        public LoginValidador()
        {
            RuleFor(login => login.Email).
                  NotNull().
                      WithMessage("O CPF não pode ser null.")
                  .NotEmpty().
                      WithMessage("O CPF é requerido");
        }
       
    }
}