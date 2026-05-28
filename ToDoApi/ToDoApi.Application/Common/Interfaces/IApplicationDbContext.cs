using Microsoft.EntityFrameworkCore;
using ToDoApi.Domain.Entities;

namespace ToDoApi.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Category> Categories { get; }
        DbSet<TaskItem> TaskItems { get; }
    }
}
