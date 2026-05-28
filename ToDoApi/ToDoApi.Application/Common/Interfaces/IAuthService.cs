using ToDoApi.Domain.Entities;

namespace ToDoApi.Application.Common.Interfaces
{
    public interface IAuthService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
        string CreateToken(User user);
    }
}
