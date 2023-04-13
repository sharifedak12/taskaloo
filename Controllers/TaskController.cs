using Microsoft.AspNetCore.Mvc;
using taskaloo.Repositories;
using taskaloo.Services;
using taskaloo.Utility;
using static Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenerator;

namespace taskaloo.Models;

[ApiController]
[Route("/tasks")]
public class TaskItemController : ControllerBase
{
    private readonly ILoggerService _logger;
    private readonly ITaskService _taskService;

    public TaskItemController(ILoggerService logger, ITaskService taskService)
    {
        _logger = logger;
        _taskService = taskService;
    }

    [HttpGet(Name = "Tasks")]
    
    public async Task<ActionResult<List<TaskItem>>> GetTasksByUserId(Guid userId)
    {
        _logger.LogInfo("Getting all tasks");
        var tasks = await _taskService.GetTasks(userId);
        return Ok(tasks);
    }
}
