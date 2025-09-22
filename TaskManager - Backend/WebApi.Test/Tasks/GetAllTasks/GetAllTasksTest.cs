using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using TaskManager.Communication.Responses;

namespace WebApi.Test.Tasks.GetAllTasks
{
    public class GetAllTasksTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public GetAllTasksTest(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        //TESTE PARA SUCESSO, com parametros validos;
        //OBS: Nao estou usando banco em memoria justamente pq os metodos testados nao escrevem no banco.
        //Em caso de testes para registrar tarefas, por exemplo, seria necessário criar um banco em memoria
        //para evitar persistencia de dados falsos no banco de dados.

        [Fact]
        public async Task GetAllTasksSucess()
        {
            //URL que foi retirada do swagger com os parametros passaos.
            var url = "api/task?page=1&pageSize=10&sort=id&order=asc";


            //var url = "api/task?page=1&pageSize=10&title=expedita&sort=id&order=asc";


            var response = await _httpClient.GetAsync(url);

            // validação do status
            Assert.Equal(HttpStatusCode.OK, response.StatusCode); //valida se o statuscode
                                                                  //ok é igual o statuscode do
                                                                  //response


            // validação do conteudo
            // #OBS: mudar essa validação
            // em caso de modificação da URL
            var result = await response.Content.ReadFromJsonAsync<ResponseAllTasks>();
            Assert.NotNull(result);
            Assert.True(result.Tasks.Count <= 10);
        }


        [Fact]
        public async Task GetAllTasksSucessFailed()
        {
            var url = "/api/task?page=0&pageSize=0&sort=id&order=asc";
            var response = await _httpClient.GetAsync(url);

           Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();

            Assert.Contains("page and page size must be greater than 0", content);  // Nesse caso verifica se a mensagem retornada
                                                                                    // é a mesma do primeiro parametro.
                                                                                    // Se for, nao mostra erro.
        }



    }
}
