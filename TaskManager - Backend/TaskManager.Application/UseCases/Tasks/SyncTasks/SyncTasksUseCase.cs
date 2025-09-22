using Newtonsoft.Json;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.Tasks;

namespace TaskManager.Application.UseCases.Tasks.SyncTasks
{
    public class SyncTasksUseCase : ISyncTasksUseCase
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITasksWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public SyncTasksUseCase(IHttpClientFactory httpClientFactory, ITasksWriteOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _httpClientFactory = httpClientFactory;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {

            //Prepara o httpclient para buscar na API externa
            var client = _httpClientFactory.CreateClient();

            //Pega os dados e armazena na variavel response.
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos");

            var json = await response.Content.ReadAsStringAsync();

            var externalTasks = JsonConvert.DeserializeObject<List<ExternalDTO>>(json) ?? new List<ExternalDTO>(); //Lista vazia para caso o external tasks voltar vazio!
            //No caso do teste em questão nao vai retornar nula pq é uma API fixa com os mesmos dados sempre.



            int savedCounted = 0; // Essa variavel vai ser usada para contar quantas tarefas foram salvas no banco dentro do looping. 

            foreach (var dto in externalTasks)
            {

                //Essa função vem do repositorio e compara o ID da API externa com o ExternalID do banco de dados//
                //Metodo desenvolvido para não ocorrer persistencia duplicada no banco de dados.
                bool exists = await _repository.ExistsByExternalId(dto.id); 
                if (exists) continue;

                var task = new TasksEntity
                {
                    ExternalId = dto.id,
                    userId = dto.UserId,
                    title = dto.title,
                    completed = dto.completed,
                };

                await _repository.Add(task);

                savedCounted++;
            }

            await _unitOfWork.Commit();

            return savedCounted;
        }
    }
}
