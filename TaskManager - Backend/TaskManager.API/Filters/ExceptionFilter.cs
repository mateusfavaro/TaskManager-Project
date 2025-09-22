using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskManager.Communication.Responses;
using TaskManager.Exception.ExceptionTasks;

namespace TaskManager.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            
            if (context.Exception is TasksException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnknowError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {

            var TaskException = context.Exception as TasksException;
            var errorResponse = new ResponseErrorJson(TaskException!.GetErrors());

            context.HttpContext.Response.StatusCode = TaskException.StatusCode;
            context.Result = new ObjectResult(errorResponse);

        }

        private void ThrowUnknowError(ExceptionContext context)
        {
            var error = new List<string>();
            error.Add("UnknownError");

            var errorResponse = new ResponseErrorJson(string.Empty)
            {
                ErrorMessage = error
            };

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }


        
    }
}
