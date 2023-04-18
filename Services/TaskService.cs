using taskaloo.Models;
using taskaloo.Repositories;

namespace taskaloo.Services;

public interface ITaskService

{
    Task<TaskItem> GetTaskById(int id);
    Task<List<TaskItem>> GetTasks(Guid userId);
    Task<TaskItem> AddTask(TaskItem task);
    Task<TaskItem> UpdateTask(int taskId, TaskItem task);
    Task<bool> DeleteTask(int id);
}

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    
    public async Task<TaskItem> GetTaskById(int id)
    {
        return await _taskRepository.GetTask(id) ?? throw new InvalidOperationException();
    }
    
    public async Task<List<TaskItem>> GetTasks(Guid userId)
    {
        return await _taskRepository.GetTasksByUser(userId);
    }
    
    public async Task<TaskItem> AddTask(TaskItem task)
    {
        await _taskRepository.AddTask(task);
        return task;
    }

    public async Task<TaskItem> UpdateTask(int taskId, TaskItem task)
    {
        return await _taskRepository.UpdateTask(taskId, task);
    }
    public async Task<bool> DeleteTask (int id)
    {
        var task = await _taskRepository.GetTask(id);
        if (task == null)
        {
            return false;
        }
        await _taskRepository.DeleteTask(id);
        return true;
    }

}