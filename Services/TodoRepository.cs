using TodoNET6.Models;

namespace TodoNET6.Services
{
    public interface ITodoRepository : IRepository<Todo, int> {}
}