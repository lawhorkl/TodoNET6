using TodoNET6.Controllers;

namespace TodoNET6
{
    public static class RouteExtensions
    {
        private static IEnumerable<Action<WebApplication>> apis =
            new List<Action<WebApplication>>
            {
                TodoRoutes
            };

        public static void MapRoutes(this WebApplication app)
        {
            foreach (var api in apis)
            {
                api(app);
            }
        }

        private static void TodoRoutes(WebApplication app)
        {
            app.MapGet("/task", TodoController.GetTodos);
            app.MapGet("/task/{id:Guid}", TodoController.GetTodo);
            app.MapPost("/task", TodoController.CreateTodo);
            app.MapPost("/task/{id:Guid}", TodoController.UpdateTodo);
            app.MapDelete("/task/{id:Guid}", TodoController.DeleteTodo);
        }
    }
}