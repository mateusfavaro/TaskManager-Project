namespace TaskManager.Exception.ExceptionTasks
{
    public abstract class TasksException : System.Exception
    {

        protected TasksException(string message) : base(message)
        {
            
        }

        public abstract int StatusCode { get; }

        public abstract List<string> GetErrors();


    }
}
