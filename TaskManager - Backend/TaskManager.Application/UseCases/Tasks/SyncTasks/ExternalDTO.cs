namespace TaskManager.Application.UseCases.Tasks.SyncTasks
{
    public class ExternalDTO
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string title { get; set; } = string.Empty;
        public bool completed { get; set; }

    }
}
