namespace ToDoApi.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        //Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
        void Delete(T entity);
    }
}