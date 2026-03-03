using FinanceApp.Domain.ValueObjects;
using System;
using System.Net.Http.Headers;

namespace FinanceApp.Domain.Entities
{
    /* Protege estado interno
     * Não permite criação inválida
     * Impede alteração direta indevida
     * Tem construtor controlado
    */
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; private set; }

        // Construtor principal
        public User(string name, Email email, string passwordHash)
        {
            Validate(name, email, passwordHash);

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        private void Validate(string name, Email email, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Senha não pode ser vazia.");
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Nome não pode ser vazio.");

            Name = newName;
        }
    }
}