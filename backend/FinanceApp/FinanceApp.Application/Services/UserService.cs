using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;
using FinanceApp.Domain.ValueObjects;

namespace FinanceApp.Application.Services
{
    /*
     * O que faz?
     * Cria usuário
     * Busca por email
     * Garante que não exista duplicado
     * 
     * ✔ Application depende apenas de interface
     * ✔ Domain continua isolado
     * ✔ UI futuramente chamará apenas Application
     * ✔ Nenhuma dependência de banco ainda
     * 
     * ✔ Email só pode ser criado via Create()
     * ✔ Validação está centralizada no Value Object
     * ✔ Application respeita o domínio
     * ✔ Nenhum acesso indevido ao construtor
     * ✔ Nome correto da propriedade (Address)
     * 🏗 Arquitetura saudável
     * Value Object controla criação
     * Entidade recebe objeto válido
     * Application apenas orquestra
     * Isso é Clean Architecture + DDD na prática.
    */

    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateUserAsync(string name, string email, string password)
        {
            var emailVO = Email.Create(email);

            var existingUser = await _userRepository.GetByEmailAsync(emailVO.Address);

            if (existingUser != null)
                throw new Exception("Já existe usuário com este email.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User(name, emailVO, passwordHash);

            await _userRepository.AddAsync(user);

            return user.Id;
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
    }
}