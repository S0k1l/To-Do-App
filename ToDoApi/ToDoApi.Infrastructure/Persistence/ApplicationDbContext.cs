using Microsoft.EntityFrameworkCore;
using ToDoApi.Application.Common.Interfaces;
using ToDoApi.Domain.Entities;

namespace ToDoApi.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<TaskItem> TaskItems => Set<TaskItem>();
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
