using TodoNET6.Models;
using TodoNET6.Repositories;

namespace TodoNET6.Controllers
{
    public static class TodoController
    {
        public static async Task<IResult> GetTodos(
            ITodoRepository todoRepository
        )
        {
            var allTodos = await todoRepository.WhereAsync(todo => true);

            return Results.Ok(
                allTodos
            );
        }

        public static async Task<IResult> GetTodo(
           Guid id,
           ITodoRepository todoRepository
        )
        {
            var todo = await todoRepository.FindAsync(id);

            if (todo == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(todo);
        }

        public static async Task<IResult> CreateTodo(
            Todo todo,
            ITodoRepository todoRepository
        )
        {
            var createdTodo = await todoRepository.CreateAsync(
                todo
            );

            return Results.Ok(createdTodo);
        }

        public static async Task<IResult> UpdateTodo(
            Guid id,
            Todo todo,
            ITodoRepository todoRepository
        )
        {
            var updatedTodo = await todoRepository.UpdateAsync(
                id,
                todo
            );

            return Results.Ok(updatedTodo);
        }

        public static async Task<IResult> DeleteTodo(
            Guid id,
            ITodoRepository todoRepository
        )
        {
            var todo = await todoRepository.DeleteAsync(id);

            return Results.Ok(todo);
        }
    }
}