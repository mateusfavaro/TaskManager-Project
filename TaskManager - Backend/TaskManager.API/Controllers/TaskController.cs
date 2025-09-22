using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Tasks.GetAll;
using TaskManager.Application.UseCases.Tasks.GetById;
using TaskManager.Application.UseCases.Tasks.SyncTasks;
using TaskManager.Application.UseCases.Tasks.UpdateTask;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        //TODAS AS EXCEÇÕES ESTÃO SENDO TRATADAS POR UM FILTRO DE EXCEÇÕES CONFIGURADO DENTRO DE API/FILTER. POR ISSO NÃO ESTÁ SENDO USADO TRY/CATCH.

        [HttpPost]
        [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
        public async Task<IActionResult> SyncTasks([FromServices] ISyncTasksUseCase useCase)
        {
            var count = await useCase.Execute();

            if (count == 0)
            {
                return Ok("No tasks were saved in the database.");
            }
            return Ok($"{count}tasks were saved in the database.");
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseTasksJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTaskById(
            [FromServices] IGetTaskByIdUseCase useCase,
            [FromRoute] int id)
        {
            var result = await useCase.Execute(id);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllTasks([FromServices] IGetTasksUseCase useCase,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? title = null,
            [FromQuery] string sort = "id",
            [FromQuery] string order = "asc"
            )
        {

            var result = await useCase.Execute(page, pageSize, title, sort, order);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromServices] IUpdateTaskUseCase useCase,
            [FromRoute] int id,
            [FromBody] RequestTasksJson request
            )
        {
            await useCase.Execute(request, id);

            return NoContent();
        }
    }
}
