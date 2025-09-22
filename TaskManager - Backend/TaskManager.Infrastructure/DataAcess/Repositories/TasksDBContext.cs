using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.DataAcess.Repositories
{
    public class TasksDBContext : DbContext
    {

        public TasksDBContext(DbContextOptions options) : base(options) { }

        public DbSet<TasksEntity> Tasks { get; set; }

    }
}
