using Todo.Data.Infrastructure;
using Todo.Models;
using Todo.Services.BaseServices;

namespace Todo.Services
{
    public class TodoServices : BaseServices<TodoP>, ITodoServices
    {
        public TodoServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
