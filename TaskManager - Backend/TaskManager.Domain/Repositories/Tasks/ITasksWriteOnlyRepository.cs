using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Repositories.Tasks
{
    public interface ITasksWriteOnlyRepository
    {

        Task Add(TasksEntity task);

        Task<bool> ExistsByExternalId(int externalId);

    }
}
