using System.Data.Entity;
using Todo.Models;

namespace Todo.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext():base("TodoCnn")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<TodoP> TodoPs { get; set; }
    }
}
