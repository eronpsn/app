using FluentValidation.Results;
using System;
using Eclilar.Dominio.Validadores;

namespace Eclilar.Dominio.ObjetosValor {
    public class Cpf {

        public string Numero { get; private set; }

        private Cpf(string numero) {
            Numero = numero;
        }

        public ValidationResult Validar() {
            var cpfValidador = new CpfValidador();
            var resultadosValidacao = cpfValidador.Validate(this);
            return resultadosValidacao;
        }

        public void ColocarMascara() {
            if (Numero.Length == 11) {
                var digitos = Numero.ToCharArray();
                var novoFormato = new char[14];
                novoFormato[0] = digitos[0];
                novoFormato[1] = digitos[1];
                novoFormato[2] = digitos[2];

                novoFormato[3] = '.';

                novoFormato[4] = digitos[3];
                novoFormato[5] = digitos[4];
                novoFormato[6] = digitos[5];

                novoFormato[7] = '.';

                novoFormato[8] = digitos[6];
                novoFormato[9] = digitos[7];
                novoFormato[10] = digitos[8];

                novoFormato[11] = '-';

                novoFormato[12] = digitos[9];
                novoFormato[13] = digitos[10];

                Numero = new string(novoFormato);
            }
        }

        public override bool Equals(object obj) {
            return obj is Cpf cpf &&
                   Numero == cpf.Numero;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Numero);
        }

        public static implicit operator Cpf(string numero) => new(numero);

        public static bool operator ==(Cpf cpf1, Cpf cpf2) {
            return cpf1.Numero.Equals(cpf2.Numero);
        }

        public static bool operator !=(Cpf cpf1, Cpf cpf2) {
            return !(cpf1 == cpf2);
        }
    }
}
