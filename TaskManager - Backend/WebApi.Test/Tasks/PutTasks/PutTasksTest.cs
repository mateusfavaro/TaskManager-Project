using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using TaskManager.Communication.Requests;

namespace WebApi.Test.Tasks.PutTasks
{
    public class PutTasksTest : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly HttpClient _httpClient;

        public PutTasksTest(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }


        [Fact]
        public async Task UpdateTaskCompleted()
        {
            //Para o teste passar, o id 34 que ja está como true. Como não estamos utilizando dados inmemory,
            //a persistencia será aplicada ao banco. Sem pejuizo nos dados já que se for true ele vai dar sucesso, se for false
            //vai falhar em razão da validação de nao poder alterar caso tenha 5 tasks como false.
            var taskId = 34;
            var url = $"api/task/{taskId}";

            var request = new RequestTasksJson
            {
                completed = true
            };

            // Act
            var response = await _httpClient.PutAsJsonAsync(url, request);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }


        [Fact]
        public async Task UpdateTaskBadRequest()
        {

            var taskId = 34;
            var url = $"api/task/{taskId}";

            var request = new RequestTasksJson
            {
                completed = false
            };

            // Act
            var response = await _httpClient.PutAsJsonAsync(url, request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateTaskNotFound()
        {

            var taskId = 999; // erro de id nao encontrado, portanto,
                              // passando um id maior do que temos disponivel no banco

            var url = $"api/task/{taskId}";

            var request = new RequestTasksJson
            {
                completed = false
            };

            // Act
            var response = await _httpClient.PutAsJsonAsync(url, request);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
