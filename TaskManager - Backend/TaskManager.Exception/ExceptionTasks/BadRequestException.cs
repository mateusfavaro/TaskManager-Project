
using System.Net;

namespace TaskManager.Exception.ExceptionTasks
{
    public class BadRequestException : TasksException
    {

        public BadRequestException(string message) : base(message) { }

        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
