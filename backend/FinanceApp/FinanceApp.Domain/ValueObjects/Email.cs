using System;
using System.Text.RegularExpressions;

namespace FinanceApp.Domain.ValueObjects
{
    /*
     * O que é um Value Object?
     * Diferente de Entity:
     * Entity tem identidade (Id)
     * Value Object é definido apenas por seus valores
     * É imutável
     * Não tem Id
     * Não pode existir em estado inválido
     * 👉 Email é perfeito para virar Value Object.
     * Porque:
     * Tem regras próprias
     * Tem validação específica
     * Deve ser sempre válido
     * Não faz sentido existir um Email inválido
     * 
     * O que foi feito aqui?
     * ✔ Classe sealed (não pode herdar)
     * ✔ Construtor privado
     * ✔ Método de criação controlado
     * ✔ Imutável
     * ✔ Implementa igualdade por valor
     * ✔ Nunca existe Email inválido
    */

    public sealed class Email : IEquatable<Email>
    {
        // classe sealed não pode herdar (Value Object)
        public string Address { get; }

        private Email(string address)
        {
            Address = address;
        }

        public static Email Create(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Email cannot be empty.");

            if (!IsValidEmail(address))
                throw new ArgumentException("Invalid email format.");

            return new Email(address.Trim().ToLower());
        }

        private static bool IsValidEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public override bool Equals(object obj)
            => Equals(obj as Email);

        public bool Equals(Email other)
            => other != null && Address == other.Address;

        public override int GetHashCode()
            => Address.GetHashCode();

        public override string ToString()
            => Address;
    }
}