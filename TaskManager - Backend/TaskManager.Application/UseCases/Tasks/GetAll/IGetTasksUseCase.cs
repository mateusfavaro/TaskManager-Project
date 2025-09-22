using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks.GetAll
{
    public interface IGetTasksUseCase
    {
        Task<ResponseAllTasks> Execute(int page = 1, 
            int pageSize = 10, 
            string? title = null,
            string sort = "id", 
            string order = "asc");
    }
}
