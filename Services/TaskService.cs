using taskaloo.Models;
using taskaloo.Repositories;

namespace taskaloo.Services;

public interface ITaskService

{
    Task<TaskItem> GetTaskById(int id);
}

public class TaskService
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
    
    public async Task<IEnumerable<TaskItem?>> GetTasks()
    {
        return await _taskRepository.GetTasks();
    }

}