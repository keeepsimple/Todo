using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Todo.Models;

namespace Todo.Api.ViewModels
{
    public class TodoViewModel
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public Status Status { get; set; }
    }
}