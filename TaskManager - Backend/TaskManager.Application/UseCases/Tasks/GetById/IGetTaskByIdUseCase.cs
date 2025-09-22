using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks.GetById
{
    public interface IGetTaskByIdUseCase
    {

        Task<ResponseTasksJson> Execute(int id);

    }

}
