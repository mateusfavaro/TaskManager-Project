using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.Tasks;

namespace TaskManager.Infrastructure.DataAcess.Repositories
{
    public class TasksRepository : ITasksWriteOnlyRepository, ITasksUpdateOnlyRepository, ITasksReadOnlyRepository
    {

        private readonly TasksDBContext _dbContext;

        public TasksRepository(TasksDBContext dBContext)
        {
             _dbContext = dBContext;
        }

        public async Task Add(TasksEntity task)
        {
            await _dbContext.AddAsync(task);
        }

        public async Task<int> CountIncompleteTaskByUserId(int userId)
        {
            return await _dbContext.Tasks.Where(t => t.userId == userId && !t.completed).CountAsync();
        }

        public async Task<bool> ExistsByExternalId(int externalId)
        {
            return await _dbContext.Tasks.AnyAsync(t => t.ExternalId == externalId);
        }

        public async Task<List<TasksEntity>> GetAll()
        {
            return await _dbContext.Tasks.AsNoTracking().ToListAsync();
        }

        public void Update(TasksEntity taskEntity)
        {
            _dbContext.Tasks.Update(taskEntity);
        }

        async Task<TasksEntity?> ITasksUpdateOnlyRepository.GetById(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(t => t.id == id);
        }

        async Task<TasksEntity?> ITasksReadOnlyRepository.GetById(int id)
        {
            return await _dbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.id == id);
        }
    }
}
