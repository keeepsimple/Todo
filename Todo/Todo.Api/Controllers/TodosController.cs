using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Todo.Api.ViewModels;
using Todo.Models;
using Todo.Services;

namespace Todo.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TodosController : ApiController
    {
        private readonly ITodoServices _todoServices;

        public TodosController(ITodoServices todoServices)
        {
            _todoServices = todoServices;
        }

        // GET: api/Todos
        public async Task<IEnumerable<TodoP>> GetTodoPs()
        {
            return await _todoServices.GetAllAsync();
        }

        // GET: api/Todos/5
        [ResponseType(typeof(TodoP))]
        public async Task<IHttpActionResult> GetTodoP(Guid id)
        {
            TodoP todoP = await _todoServices.GetByIdAsync(id);
            if (todoP == null)
            {
                return NotFound();
            }

            return Ok(todoP);
        }

        // PUT: api/Todos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTodoP(Guid id, TodoViewModel todoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _todoServices.GetByIdAsync(id);
            if (todo == null)
            {
                return BadRequest();
            }

            todo.Content = todoViewModel.Content;
            todo.Status = todoViewModel.Status;

            var result = await _todoServices.UpdateAsync(todo);
            if (!result)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Todos
        [ResponseType(typeof(TodoP))]
        public async Task<IHttpActionResult> PostTodoP(TodoViewModel todoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = new TodoP
            {
                Id = todoViewModel.Id,
                Content = todoViewModel.Content,
                Status = todoViewModel.Status
            };

            var result = await _todoServices.AddAsync(todo);
            if(result < 0)
            {
                return BadRequest(ModelState);
            }

            return CreatedAtRoute("DefaultApi", new { id = todo.Id }, todoViewModel);
        }

        // DELETE: api/Todos/5
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> DeleteTodoP(Guid id)
        {
            TodoP todoP = await _todoServices.GetByIdAsync(id);
            if (todoP == null)
            {
                return NotFound();
            }

            var result = await _todoServices.DeleteAsync(todoP);
            if (!result)
            {
                return BadRequest();
            }
            
            return Ok(true);
        }
    }
}