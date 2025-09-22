using TaskManager.Exception.ExceptionTasks;

namespace TaskManager.Application.UseCases
{
    public class TasksValidator
    {

        public bool Validate(int page, int pageSize)
        {

            var errorMessages = new List<string>();

            if (page <= 0)
            {
                errorMessages.Add(ResourceErrorMessages.PAGE_NUMBER);
            }

            if (pageSize <= 0)
            {
                errorMessages.Add(ResourceErrorMessages.PAGE_SIZE);
            }

            if (errorMessages.Count > 0)
            {
                throw new ErrorOnValidationException(errorMessages);
            }
            else
            {
                return false;
            }
   
        }


    }
}
