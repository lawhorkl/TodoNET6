using System.Linq.Expressions;
using TodoNET6.Models;

namespace TodoNET6.Services
{
    public interface ITodoRepository : IRepository<Todo, Guid> {}

    public class TodoRepository : ITodoRepository
    {
        private readonly Dictionary<Guid, Todo> _todosDict =
            new Dictionary<Guid, Todo>();
        private IEnumerable<Todo> _todos => _todosDict.Values;

        public Task<Todo> CreateAsync(Todo entity)
        {
            var newId = Guid.NewGuid();

            entity.Id = newId;
            _todosDict.Add(entity.Id, entity);

            return Task.FromResult(_todosDict[newId]);
        }

        public Task<Todo> DeleteAsync(Guid index)
        {
            var todo = _todosDict[index];

            _todosDict.Remove(index);

            return Task.FromResult(todo);
        }

        public async Task<Todo> FetchAsync(Guid index)
        {
            // stupid await task run to appease the almighty compiler god
            await Task.Run(() => {});
            if (!_todosDict.ContainsKey(index))
            {
                return null;
            }

            return _todosDict[index];
        }

        public Task<Todo> UpdateAsync(Guid index, Todo entity)
        {
            if (!_todosDict.ContainsKey(index))
            {
                entity.Id = index;
                
                _todosDict.Add(entity.Id, entity);

                return Task.FromResult(entity);
            }

            _todosDict[index] = entity;

            return Task.FromResult(entity);
        }

        public Task<IEnumerable<Todo>> WhereAsync(Expression<Func<Todo, bool>> predicate)
        {
            // Take an expression here and compile it at runtime because most ORMs use 
            // expressions with reflection to build the DB queries.
            return Task.FromResult(
                _todos.Where(predicate.Compile())
            );
        }
    }
}