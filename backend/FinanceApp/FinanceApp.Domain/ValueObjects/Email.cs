using System;
using System.Text.RegularExpressions;

namespace FinanceApp.Domain.ValueObjects
{
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