using TodoNET6.Services;

namespace TodoNET6.Models
{
    public class Todo : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}