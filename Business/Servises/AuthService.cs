using Business.Exceptions;
using Business.Models;
using Business.Policies;
using Business.Servises.IServices;
using Data.Entities;
using Data.Repositories.IRepositories;
using System.Security.Claims;

namespace Business.Servises
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, IRoleRepository roleRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _tokenService = tokenService;
        }

        public async Task RegisterUserAsync(AuthModel registerRequest)
        {
            var user = await _userRepository.GetByEmailAsync(registerRequest.Email);

            if (user != null)
            {
                throw new NotAuthenticatedException("User with that credentials already exists.");
            }
            var roles = await _roleRepository.GetAllAsync();
            var userRole = roles.First(role => role.Name == Policy.ForUserOnly);

            user = new User
            {
                Email = registerRequest.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password),
                RoleId = userRole.Id
            };

            await _userRepository.CreateAsync(user);
        }

        public async Task<LoginSuccessModel> LoginAsync(AuthModel loginRequest)
        {
            var user = await _userRepository.GetByCredentialsAsync(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                throw new NotAuthenticatedException("User with that credentials does not exist.");
            }
            var userClaims = GetUserClaims(user);
            var jwt = _tokenService.GenerateJwt(userClaims);

            return new LoginSuccessModel(user, jwt);
        }

        private static IEnumerable<Claim> GetUserClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            return claims;
        }
    }
}
