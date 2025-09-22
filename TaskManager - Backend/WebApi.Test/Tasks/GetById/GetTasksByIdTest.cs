using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using TaskManager.Communication.Responses;

namespace WebApi.Test.Tasks.GetById
{
    public class GetAllTasksTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public GetAllTasksTest(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task GetTasksByIdSucess()
        {

            var url = "api/task/37";


            var response = await _httpClient.GetAsync(url);


            Assert.Equal(HttpStatusCode.OK, response.StatusCode); 


    
            var result = await response.Content.ReadFromJsonAsync<ResponseTasksJson>();
            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.title));
        }


        [Fact]
        public async Task GetTasksByIdFailed()
        {
            var url = "api/task/9999"; //Teste de erro com id que nao existe no banco.

            var response = await _httpClient.GetAsync(url);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Task not found.", content);
        }
    }
}
