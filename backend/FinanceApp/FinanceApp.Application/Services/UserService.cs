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