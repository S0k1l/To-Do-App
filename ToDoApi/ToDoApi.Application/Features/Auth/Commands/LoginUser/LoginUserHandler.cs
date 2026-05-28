using MediatR;
using ToDoApi.Application.Common.Interfaces;

namespace ToDoApi.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginUserHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.email);
            if (user == null || !_authService.VerifyPassword(request.password, user.PasswordHash))
            {
                return null;
            }

            return _authService.CreateToken(user);
        }
    }
}
