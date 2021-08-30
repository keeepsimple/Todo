using System;
using System.Collections.Generic;
using System.Data.Entity;
using Todo.Models;

namespace Todo.Data
{
    internal class DbInitializer : DropCreateDatabaseAlways<TodoContext>
    {
        protected override void Seed(TodoContext context)
        {
            var todo = new List<TodoP>
            {
                new TodoP
                {
                    Id = Guid.NewGuid(),
                    Content = "Test to do",
                    Status = Status.NotDone
                },
                new TodoP
                {
                    Id = Guid.NewGuid(),
                    Content = "Test to do 1",
                    Status = Status.Done
                },
                new TodoP
                {
                    Id = Guid.NewGuid(),
                    Content = "Test to do 2",
                    Status = Status.NotDone
                },
                new TodoP
                {
                    Id = Guid.NewGuid(),
                    Content = "Test to do 3",
                    Status = Status.Done
                }
            };

            context.TodoPs.AddRange(todo);
            context.SaveChanges();
        }
    }
}