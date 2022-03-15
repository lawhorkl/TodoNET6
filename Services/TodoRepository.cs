using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoNET6.db;
using TodoNET6.Models;

namespace TodoNET6.Services
{
    public interface ITodoRepository : IRepository<Todo, Guid> {}

    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationContext _context;
        private DbSet<Todo> _dbSet => _context.Set<Todo>();

        public TodoRepository(
            ApplicationContext context
        )
        {
            _context = context;
        }


        public async Task<Todo> CreateAsync(Todo entity)
        {
            var todo = _dbSet.Add(entity);

            await _context.SaveChangesAsync();

            return todo.Entity;
        }

        public async Task<Todo> DeleteAsync(Guid index)
        {
            var todo = _dbSet.Remove(new Todo { Id = index });

            await _context.SaveChangesAsync();
            
            return todo.Entity;
        }

        public async Task<Todo?> FindAsync(params object[] values)
        {
            return await _dbSet.FindAsync(values);
        }

        public async Task<Todo> UpdateAsync(Guid index, Todo entity)
        {
            entity.Id = index;

            var todo = _dbSet.Update(entity);

            await _context.SaveChangesAsync();

            return todo.Entity;
        }

        public async Task<IEnumerable<Todo>> WhereAsync(Expression<Func<Todo, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}