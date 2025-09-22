using TaskManager.Communication.Requests;

namespace TaskManager.Application.UseCases.Tasks.UpdateTask
{
    public interface IUpdateTaskUseCase
    {

        Task Execute(RequestTasksJson request, int id);

    }
}
