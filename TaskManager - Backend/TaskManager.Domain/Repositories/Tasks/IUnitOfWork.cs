namespace TaskManager.Domain.Repositories.Tasks
{
    public interface IUnitOfWork
    {

        Task Commit();

    }
}
