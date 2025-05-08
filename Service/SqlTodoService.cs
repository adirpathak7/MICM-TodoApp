using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Service
{
    public class SqlTodoService : ITodoService
    {
        private readonly ToDoDBContext toDoDBContext;

        public SqlTodoService(ToDoDBContext toDoDBContext)
        {
            this.toDoDBContext = toDoDBContext;
        }

        public async Task<List<Todo>> getTodos()
        {
            return await toDoDBContext.Todos.ToListAsync();
        }

        public async Task addTodo(Todo todo)
        {
            await toDoDBContext.Todos.AddAsync(todo);
            await toDoDBContext.SaveChangesAsync();
        }
        public async Task updateTodo(int id, Todo todo)
        {
            var existingTodo = await toDoDBContext.Todos.FindAsync(id);
            if (existingTodo == null)
            {
                throw new ArgumentException("Todo not found");
            }
            existingTodo.Title = todo.Title;
            existingTodo.isCompleted = todo.isCompleted;

            toDoDBContext.Todos.Update(existingTodo);
            await toDoDBContext.SaveChangesAsync();
        }
        public async Task deleteTodo(int id)
        {
            var existingTodo = await toDoDBContext.Todos.FindAsync(id);
            if (existingTodo == null)
            {
                throw new ArgumentException("Todo not found");
            }
            toDoDBContext.Todos.Remove(existingTodo);
            await toDoDBContext.SaveChangesAsync();
        }

    }
}
