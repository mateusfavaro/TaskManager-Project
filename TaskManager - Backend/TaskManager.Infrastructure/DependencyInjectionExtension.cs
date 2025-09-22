using Microsoft.Extensions.DependencyInjection;
using TaskManager.Domain.Repositories.Tasks;
using TaskManager.Infrastructure.DataAcess.Repositories;

namespace TaskManager.Infrastructure
{
    public static class DependencyInjectionExtension
    {

        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddRepository(services);
        }

        private static void AddRepository(IServiceCollection services)
        {

            services.AddScoped<ITasksWriteOnlyRepository, TasksRepository>();
            services.AddScoped<ITasksUpdateOnlyRepository, TasksRepository>();
            services.AddScoped<ITasksReadOnlyRepository, TasksRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

    }
}
