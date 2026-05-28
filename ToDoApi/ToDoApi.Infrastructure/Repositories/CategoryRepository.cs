using Microsoft.EntityFrameworkCore;
using ToDoApi.Application.Common.Interfaces;
using ToDoApi.Domain.Entities;
using ToDoApi.Infrastructure.Persistence;

namespace ToDoApi.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> HasTaskItemsAsync(Guid id)
        {
            return await _context.Categories.Where(c => c.Id == id)
                                            .AnyAsync(c => c.TaskItems.Any());
        }
    }
}
