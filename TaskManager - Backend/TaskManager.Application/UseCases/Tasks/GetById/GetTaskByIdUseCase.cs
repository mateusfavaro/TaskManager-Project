using TaskManager.Communication.Responses;
using TaskManager.Domain.Repositories.Tasks;
using TaskManager.Exception.ExceptionTasks;

namespace TaskManager.Application.UseCases.Tasks.GetById
{
    public class GetTaskByIdUseCase : IGetTaskByIdUseCase
    {

        private readonly ITasksReadOnlyRepository _repository;

        public GetTaskByIdUseCase(ITasksReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseTasksJson> Execute(int id)
        {
            var result = await _repository.GetById(id);

            if (result == null)
            {
                throw new NotFoundException(ResourceErrorMessages.NOT_FOUND);
            }

            return new ResponseTasksJson
            {

                id = result.id,
                completed = result.completed,
                title = result.title,
                userId = result.userId
            };

        }
    }
}
