using Microsoft.AspNetCore.Mvc;
using taskaloo.Models;
using taskaloo.Repositories;
using taskaloo.Utility;

namespace taskaloo.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskItemController : ControllerBase
{
    private readonly ILoggerService _logger;
    private readonly ITaskRepository _taskRepository;

    public TaskItemController(ILoggerService logger, ITaskRepository taskRepository)
    {
        _logger = logger;
        _taskRepository = taskRepository;
    }

    [HttpGet(Name = "Tasks")]
    

public async Task<List<TaskItem?>> GetTasks()
    {
        var tasks = await _taskRepository.GetTasks();
        return tasks;
    }
}
