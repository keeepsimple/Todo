using System;

namespace Todo.Models
{
    public class TodoP
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public Status Status { get; set; }
    }
}
