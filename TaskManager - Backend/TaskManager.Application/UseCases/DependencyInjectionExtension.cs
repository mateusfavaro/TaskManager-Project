using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.UseCases.Tasks.GetAll;
using TaskManager.Application.UseCases.Tasks.GetById;
using TaskManager.Application.UseCases.Tasks.SyncTasks;
using TaskManager.Application.UseCases.Tasks.UpdateTask;

namespace TaskManager.Application.UseCases
{
    public static class DependencyInjectionExtension
    {

        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCase(services);
        }

        private static void AddUseCase(IServiceCollection services)
        {
            services.AddScoped<ISyncTasksUseCase, SyncTasksUseCase>();
            services.AddScoped<IUpdateTaskUseCase, UpdateTaskUseCase>();
            services.AddScoped<IGetTaskByIdUseCase, GetTaskByIdUseCase>();
            services.AddScoped<IGetTasksUseCase, GetTasksUseCase>();
        }

    }
}
