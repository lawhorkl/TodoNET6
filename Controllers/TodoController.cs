using TodoNET6.Models;
using TodoNET6.Services;

namespace TodoNET6.Controllers
{
    public static class TodoController
    {
        public static async Task<IResult> GetTodos(
            ITodoRepository todoRepository
        )
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetTodo(
           int id,
           ITodoRepository todoRepository
        )
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> CreateTodo(
            Todo todo,
            ITodoRepository todoRepository
        )
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> UpdateTodo(
            int id,
            Todo todo,
            ITodoRepository todoRepository
        )
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> DeleteTodo(
            int id,
            ITodoRepository todoRepository
        )
        {
            throw new NotImplementedException();
        }
    }
}