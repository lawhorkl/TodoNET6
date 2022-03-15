using Microsoft.AspNetCore.Mvc;
using TodoNET6.Models;
using TodoNET6.Services;

namespace TodoNET6.Controllers
{
    [ApiController]
    [Route("task")]
    public class NewTodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public NewTodoController(
            ITodoRepository todoRepository
        )
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            var results = await _todoRepository
                .WhereAsync(todo => true);

            return results.ToList();
        }

        [HttpGet("{uuid}")]
        public async Task<ActionResult<Todo>> GetTodo(Guid uuid)
        {
            var todoFromDb = await _todoRepository.FindAsync(uuid);

            if (todoFromDb == null)
            {
                return NotFound();
            }

            return todoFromDb;
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo([FromBody]Todo todo)
        {
            var createdTodo = await _todoRepository.CreateAsync(todo);

            return createdTodo;
        }

        [HttpPut("{uuid}")]
        public async Task<ActionResult<Todo>> UpdateTodo(
            Guid uuid, 
            [FromBody] Todo todoToUpdate
        )
        {
            var updatedTodo = await _todoRepository.UpdateAsync(uuid, todoToUpdate);

            return updatedTodo;
        }

        [HttpDelete("{uuid}")]
        public async Task<ActionResult<Todo>> DeleteTodo(Guid uuid)
        {
            var deletedTodo = await _todoRepository.DeleteAsync(uuid);

            return deletedTodo;
        }
    }
}