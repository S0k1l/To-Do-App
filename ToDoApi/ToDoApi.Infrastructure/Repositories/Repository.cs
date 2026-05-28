using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoApi.Domain.Common;
using ToDoApi.Domain.Interfaces;
using ToDoApi.Infrastructure.Persistence;

namespace ToDoApi.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        {
            return await _context.Set<T>().AnyAsync(predicate, ct);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }

}
