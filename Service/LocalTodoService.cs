using ToDoApp.Models;

namespace ToDoApp.Service
{
    public class LocalTodoService : ITodoService
    {
        private static readonly List<Todo> todos = new List<Todo>();

        public async Task<List<Todo>> getTodos()
        {
            return await Task.FromResult(todos.ToList());
        }

        public async Task addTodo(Todo todo)
        {
            todos.Add(todo);
            await Task.CompletedTask;
        }

        public async Task updateTodo(int id, Todo todo)
        {
            var existingTodo = todos.FirstOrDefault(t => t.Id == id);
            if (existingTodo == null)
            {
                throw new ArgumentException("Todo not found");
            }
            existingTodo.Title = todo.Title;
            existingTodo.isCompleted = todo.isCompleted;
            await Task.CompletedTask;
        }

        public async Task deleteTodo(int id)
        {
            var existingTodo = todos.FirstOrDefault(t => t.Id == id);
            if (existingTodo == null)
            {
                throw new ArgumentException("Todo not found");
            }
            todos.Remove(existingTodo);
            await Task.CompletedTask;
        }
    }
}
