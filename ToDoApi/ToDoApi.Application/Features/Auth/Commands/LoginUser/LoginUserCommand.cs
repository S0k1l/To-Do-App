using MediatR;

namespace ToDoApi.Application.Features.Auth.Commands.LoginUser
{
    public record LoginUserCommand(string email, string password) : IRequest<string>;

}
