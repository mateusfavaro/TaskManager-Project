using TaskManager.Communication.Responses;
using TaskManager.Domain.Repositories.Tasks;
using TaskManager.Exception.ExceptionTasks;

namespace TaskManager.Application.UseCases.Tasks.GetAll
{
    public class GetTasksUseCase : IGetTasksUseCase
    {

        private readonly ITasksReadOnlyRepository _repository;

        public GetTasksUseCase(ITasksReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseAllTasks> Execute(int page = 1, 
            int pageSize = 10, 
            string? title = null, 
            string sort = "id", 
            string order = "asc")
        {

            GetAllValidator(page, pageSize);

            var tasks = await _repository.GetAll();

            //Filtro
            if (!string.IsNullOrWhiteSpace(title))
            {
                tasks = tasks.Where(t => t.title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();    //Caso titulo for passado na query, filtra por titulo
            }

            //Ordenação
            tasks = sort switch
            {
                "title" => order == "desc" ? tasks.OrderByDescending(t => t.title).ToList() : tasks.OrderBy(t => t.title).ToList(),
                "userId" => order == "desc" ? tasks.OrderByDescending(t => t.userId).ToList() : tasks.OrderBy(t => t.userId).ToList(),
                _ => order == "desc" ? tasks.OrderByDescending(t => t.id).ToList() : tasks.OrderBy(t => t.id).ToList()
            };
            //Para relembrar: Se sort for igual "title" -> a ordenação é feita pelo campo title
            //se sorte for igual userid -> a ordernação é feita pelo campo userID do banco de daos;
            //qualquer outro valor é o default. Ordena por Id



            //Paginação
            var pagedTasks = tasks.Skip((page - 1) * pageSize).Take(pageSize).ToList();


            return new ResponseAllTasks
            {
                Tasks = pagedTasks.Select(t => new ResponseTasksJson
                {
                    id = t.id,
                    title = t.title,
                    completed = t.completed,
                    userId = t.userId,
                }).ToList()
            };
        }


        private void GetAllValidator(int page, int pageSize)
        {

            if( page < 1 || pageSize < 1)
            {
                throw new BadRequestException("page and page size must be greater than 0.");
            }
            ;

        }

    }
}
