using Microsoft.EntityFrameworkCore;
using ToDoApi.Application.Common.Interfaces;
using ToDoApi.Domain.Entities;
using ToDoApi.Infrastructure.Persistence;

namespace ToDoApi.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
