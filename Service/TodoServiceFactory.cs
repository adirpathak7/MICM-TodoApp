using ToDoApp.Models;

namespace ToDoApp.Service
{
    public class TodoServiceFactory
    {
        private readonly IServiceProvider serviceProvider;

        public TodoServiceFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ITodoService getService(StorageType storageType)
        {
            return storageType switch
            {
                StorageType.SqlServer => serviceProvider.GetRequiredService<SqlTodoService>(),
                StorageType.LocalStorage => serviceProvider.GetRequiredService<LocalTodoService>(),
                StorageType.TextFile=> serviceProvider.GetRequiredService<FileTodoService>(),
                _ => throw new ArgumentException("Invalid storage type"),
            };
        }
    }
}
