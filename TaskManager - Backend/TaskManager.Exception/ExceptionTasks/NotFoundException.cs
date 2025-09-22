
using System.Net;

namespace TaskManager.Exception.ExceptionTasks
{
    public class NotFoundException : TasksException
    {

        public NotFoundException(string message) : base(message)
        {
            
        }

        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
