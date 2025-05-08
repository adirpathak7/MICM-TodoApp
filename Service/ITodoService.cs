using ToDoApp.Models;

namespace ToDoApp.Service
{
    public interface ITodoService
    {
        Task<List<Todo>> getTodos();
        Task addTodo(Todo todo);
        Task updateTodo(int id, Todo todo);
        Task deleteTodo(int id);
    }
}
