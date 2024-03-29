using System.Text.Json;
using Eclilar.Aplicacao.Utils;
using FluentValidation;

namespace Eclilar.WebApi.Services
{
    public class BaseService
    {
         protected void Validate<TV, TM>(TV validacao, TM viewModel) where TV: AbstractValidator<TM>
        {
            var validador = validacao.Validate(viewModel);

            if (validador.IsValid) return;

            throw CustomException.ErroValidacao(JsonSerializer.Serialize(validador.Errors));
        }

        protected void EntidadeNaoEncontrada(string mensagem)
        {
            throw CustomException.EntityNotFound(JsonSerializer.Serialize(new { erro = mensagem }));
        }
    }
    
}