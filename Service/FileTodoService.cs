using System.Text.Json;
using ToDoApp.Models;

namespace ToDoApp.Service
{
    public class FileTodoService : ITodoService
    {

        private readonly string filePath = "fileStorage.json";

        private List<Todo> loadFile()
        {
            if (!File.Exists(filePath))
            {
                return new List<Todo>();
            }
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Todo>>(json) ?? new List<Todo>();
        }

        private void saveFile(List<Todo> todos)
        {
            var json = JsonSerializer.Serialize(todos);
            File.WriteAllText(filePath, json);
        }


        public Task<List<Todo>> getTodos()
        {
            return Task.FromResult(loadFile());
        }

        public Task addTodo(Todo todo)
        {
            var todos = loadFile();
            todos.Add(todo);
            saveFile(todos);
            return Task.FromResult(todos);
        }

        public Task updateTodo(int id, Todo todo)
        {
            var todos = loadFile();
            var existingTodo = todos.FirstOrDefault(t => t.Id == id);
            if (existingTodo != null)
            {
                existingTodo.Title = todo.Title;
                existingTodo.isCompleted = todo.isCompleted;
                saveFile(todos);
            }
            return Task.CompletedTask;
        }

        public Task deleteTodo(int id)
        {
            var todos = loadFile();
            var existingTodo = todos.FirstOrDefault(t => t.Id == id);
            if (existingTodo != null)
            {
                todos.Remove(existingTodo);
                saveFile(todos);
            }
            return Task.FromResult(todos);
        }
    }
}
