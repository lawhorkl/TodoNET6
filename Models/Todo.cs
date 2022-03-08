using TodoNET6.Services;

namespace TodoNET6.Models
{
    public class Todo : IEntity<int>
    {
        public int Id { get; set; }
    }
}