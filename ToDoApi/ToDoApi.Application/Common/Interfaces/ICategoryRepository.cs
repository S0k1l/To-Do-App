using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.Common.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> HasTaskItemsAsync(Guid id);
    }
}
