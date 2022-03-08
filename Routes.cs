using TodoNET6.Controllers;

namespace TodoNET6
{
    public static class RouteExtensions
    {
        public static void Routes(this WebApplication app)
        {
            app.MapGet("/todos", TodoController.GetTodos);
        }
    }
}