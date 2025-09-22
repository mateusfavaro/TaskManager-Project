using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Repositories.Tasks
{
    public interface ITasksUpdateOnlyRepository
    {

        Task<TasksEntity?> GetById(int id);

        void Update(TasksEntity taskEntity);

        Task<int> CountIncompleteTaskByUserId(int userId);


    }
}
