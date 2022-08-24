using FluentValidation;
using Eclilar.Dominio.ObjetosValor;

namespace Eclilar.Dominio.Validadores {
    public class CpfValidador : AbstractValidator<Cpf> {

        public CpfValidador() {
            CriarRegraFormato();
        }

        private void CriarRegraFormato() {
            RuleFor(cpf => cpf.Numero).
                NotNull().
                WithMessage("O CPF não pode ser nulo").
                NotEmpty().
                WithMessage("O CPF é requerido").
                Matches("^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$").
                WithMessage("O CPF não possui um formato válido. Formato: ddd.ddd.ddd-dd").
                Custom((numero, context) => {
                    if (!VerificarDigitos(numero)) {
                        context.AddFailure("Dígitos verificadores incorretos");
                    }
                });
        }

        private bool VerificarDigitos(string cpf) {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11) {
                return false;
            }
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++) {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }
            resto = soma % 11;
            if (resto < 2) {
                resto = 0;
            }
            else {
                resto = 11 - resto;
            }
            digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++) {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }
            resto = soma % 11;
            if (resto < 2) {
                resto = 0;
            }
            else {
                resto = 11 - resto;
            }
            digito += resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
