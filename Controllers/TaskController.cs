using Microsoft.AspNetCore.Mvc;
using taskaloo.Models;
using taskaloo.Services;
using taskaloo.Utility;

namespace taskaloo.Controllers;

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
    [HttpPost(Name = "AddTask")]
    public async Task<TaskItem> AddTask(TaskItem task)
    {
        await _taskService.AddTask(task);
        return task;
    }
    [HttpPut(Name = "UpdateTask")]
    public async Task<TaskItem> UpdateTask(int id, TaskItem task)
    {
        return await _taskService.UpdateTask(id, task);
    }
    [HttpDelete(Name = "DeleteTask")]
    public async Task<bool> DeleteTask(int id)
    {
        return await _taskService.DeleteTask(id);
    }
}
