using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Repositories.Tasks
{
    public interface ITasksReadOnlyRepository
    {

        Task<TasksEntity?> GetById(int id);

        Task<List<TasksEntity>> GetAll();

    }
}
