using taskaloo.Models;
using taskaloo.Repositories;

namespace taskaloo.Services;

public interface ITaskService

{
    Task<TaskItem> GetTaskById(int id);
    Task<List<TaskItem>> GetTasks(Guid userId);
}

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    
    public async Task<TaskItem?> GetTaskById(int id)
    {
        return await _taskRepository.GetTask(id);
    }
    
    public async Task<List<TaskItem?>> GetTasks(Guid userId)
    {
        return await _taskRepository.GetTasksByUser(userId);
    }

}