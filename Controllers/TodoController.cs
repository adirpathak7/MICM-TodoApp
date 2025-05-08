using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Data;
using ToDoApp.DTO;
using ToDoApp.Models;
using ToDoApp.Service;

namespace ToDoApp.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private readonly TodoServiceFactory todoServiceFactory;

        public TodoController(TodoServiceFactory todoServiceFactory)
        {
            this.todoServiceFactory = todoServiceFactory;
        }


        [HttpGet]
        [Route("hello")]
        public IActionResult Hello()
        {
            return Ok("Hello from TodoController");
        }

        [HttpGet]
        [Route("getTodos")]
        public async Task<IActionResult> getTodos([FromQuery] StorageType storageType)
        {
            var service = todoServiceFactory.getService(storageType);
            var todos = await service.getTodos();
            return Ok(todos);
        }

        [HttpPost]
        [Route("addTodo")]
        public async Task<IActionResult> addTodo([FromQuery] StorageType storageType, [FromBody] Todo todo)
        {
            var service = todoServiceFactory.getService(storageType);
            await service.addTodo(todo);
            return Ok(todo);
        }

        [HttpPut]
        [Route("updateTodo/{id}")]
        public async Task<IActionResult> updateTodo([FromQuery] StorageType storageType, [FromRoute] int id, [FromBody] Todo todo)
        {
            var service = todoServiceFactory.getService(storageType);
            await service.updateTodo(id, todo);
            return Ok(todo);
        }

        [HttpDelete]
        [Route("deleteTodo/{id}")]
        public async Task<IActionResult> deleteTodo([FromQuery] StorageType storageType, [FromRoute] int id)
        {
            var service = todoServiceFactory.getService(storageType);
            await service.deleteTodo(id);
            return Ok();
        }
    }
}
