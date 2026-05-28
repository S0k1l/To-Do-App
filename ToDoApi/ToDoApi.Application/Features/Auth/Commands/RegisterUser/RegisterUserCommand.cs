using MediatR;

namespace ToDoApi.Application.Features.Auth.Commands.RegisterUser
{
    public record RegisterUserCommand(string email, string password, string confirmPassword) : IRequest<string>;

}
