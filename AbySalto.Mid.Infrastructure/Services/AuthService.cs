using AbySalto.Mid.Application.DTO;
using AbySalto.Mid.Application.Interfaces;
using AbySalto.Mid.Domain.Interfaces;
using AbySalto.Mid.Domain.Models;

namespace AbySalto.Mid.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly List<User> _users = new();
        private readonly ITokenGenerator _jwtTokenGenerator;
        private readonly IRepository<User> _userRepository;

        public AuthService(ITokenGenerator jwtTokenGenerator, IRepository<User> userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthorisationResponse> RegisterAsync(RegisterRequest request)
        {
            var existing = await _userRepository.FindFirstOrDefaultAsync(u => u.Email == request.Email);
            if (existing != null)
                throw new Exception("User already exists.");

            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new User(request.Email, hash);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthorisationResponse { Email = user.Email, Token = token };
        }

        public async Task<AuthorisationResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.FindFirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthorisationResponse { Email = user.Email, Token = token };
        }
    }
}
