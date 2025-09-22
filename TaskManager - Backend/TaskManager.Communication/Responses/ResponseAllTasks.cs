namespace TaskManager.Communication.Responses
{
    public class ResponseAllTasks
    {
        public List<ResponseTasksJson> Tasks { get; set; } = new List<ResponseTasksJson>();
    }
}
