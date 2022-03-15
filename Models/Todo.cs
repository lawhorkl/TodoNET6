using System.Text.Json.Serialization;
using TodoNET6.Services;

namespace TodoNET6.Models
{
    public class Todo : IEntity<Guid>
    {
        [JsonPropertyName("uuid")]
        public Guid Id { get; set; }

        [JsonPropertyName("todo")]
        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
        public bool Completed { get; set; } = false;
    }
}