using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Entities
{
    public class TasksEntity
    {
        [Key]
        public int id { get; set; }
        public int ExternalId { get; set; }
        public int userId { get; set; }
        public string title { get; set; } = string.Empty;
        public bool completed { get; set; }
    }
}
