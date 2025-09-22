namespace TaskManager.Communication.Responses
{
    public class ResponseTasksJson
    {

        public int id { get; set; }

        public int userId { get; set; }

        public string title { get; set; } = string.Empty;

        public bool completed { get; set; }
    }
}
