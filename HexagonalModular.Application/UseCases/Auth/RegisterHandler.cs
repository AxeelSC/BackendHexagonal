using HexagonalModular.Application.DTOs;
using HexagonalModular.Core.Entities;
using HexagonalModular.Core.Interfaces;
using HexagonalModular.Core.Interfaces__Ports_;
using HexagonalModular.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.UseCases.Auth
{
    public class RegisterHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> HandleAsync(string name, string email, string password)
        {
            if (await _userRepository.ExistsByEmailAsync(email))
                throw new InvalidOperationException("Email already exists");

            var emailVO = Email.Create(email);
            var hashedPassword = _passwordHasher.Hash(password);

            var user = new User(name, emailVO, hashedPassword);

            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return user;
        }
    }
}
