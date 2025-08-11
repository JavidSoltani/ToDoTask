using Microsoft.AspNetCore.Mvc;
using ToDoTask.API.Dto.Task;
using ToDoTask.Application.Tasks.Services;

namespace ToDoTask.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskItemController(
    TaskQueryService serviceQuery,
    TaskCommandService serviceCommand) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddTaskRequest request, CancellationToken cancellation)
    {
        var result = await serviceCommand.AddTask(new() { Title = request.Title, IsComplete = request.IsComplete }, cancellation);
        if (string.IsNullOrEmpty(result))
            return Ok();
        return BadRequest(result);
    }
}