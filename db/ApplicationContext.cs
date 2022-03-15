using Microsoft.EntityFrameworkCore;
using TodoNET6.Models;

namespace TodoNET6.db
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) 
            : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
    }
}