using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Business.Policies;
using Data.Entities;
using Data.Repositories.IRepositories;

namespace Business.Servises
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AuthService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task RegisterUserAsync(RegisterModel registerRequest)
        {
            var user = await _userRepository.GetByEmailAsync(registerRequest.Email);

            if (user != null)
            {
                throw new NotAuthenticatedException("User with that credentials already exists.");
            }
            var roles = await _roleRepository.GetAllAsync();
            var userRole = roles.First(role => role.Name == Roles.User.ToString());

            user = new User
            {
                Email = registerRequest.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password),
                RoleId = userRole.Id
            };

            await _userRepository.CreateAsync(user);
        }
    }
}
