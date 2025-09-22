using TaskManager.Communication.Requests;
using TaskManager.Domain.Repositories.Tasks;
using TaskManager.Exception.ExceptionTasks;

namespace TaskManager.Application.UseCases.Tasks.UpdateTask
{
    public class UpdateTaskUseCase : IUpdateTaskUseCase
    {

        private readonly ITasksUpdateOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTaskUseCase(ITasksUpdateOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task Execute(RequestTasksJson request, int id)
        {

            var tasks = await _repository.GetById(id);

            if (tasks == null)
            {
                throw new NotFoundException(ResourceErrorMessages.NOT_FOUND);
            }

            //Se a request tentar marcar como incompleta, entra no if
            if (!request.completed)
            {
                //Usa o metodo impementado no repositorio para contar quantas tarefas o userid tem incompleta e armazena a quantia na variavel
                var incompleteCount = await _repository.CountIncompleteTaskByUserId(tasks.userId);

                if (incompleteCount >= 5 && tasks.completed)
                {
                    throw new BadRequestException(ResourceErrorMessages.TASKS_INCOMPLETED_ERROR);
                }
            }

            tasks.completed = request.completed;

            _repository.Update(tasks);

            await _unitOfWork.Commit();
        }
    }
}