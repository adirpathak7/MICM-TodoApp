using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models
{
    public class Todo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public bool? isCompleted { get; set; } = false;
        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}
