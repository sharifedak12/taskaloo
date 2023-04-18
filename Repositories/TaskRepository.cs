using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using taskaloo.Data;
using taskaloo.Models;
namespace taskaloo.Repositories;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetTasksByUser(Guid userId);
    Task<TaskItem?> GetTask(int id);
    Task<TaskItem> AddTask(TaskItem task);
    Task<TaskItem> UpdateTask(int taskId, TaskItem task);
    Task<TaskItem> DeleteTask(int id);
}
public class TaskRepository : ITaskRepository
{
    private readonly BackendContext _context;
    
    public TaskRepository(BackendContext context)
    {
        _context = context;
    }
    public async Task<List<TaskItem>> GetTasksByUser(Guid userId)
    {
        try
        {
            var tasks = _context.Tasks.Where(t=> t.UserId == userId);
            return await tasks.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<TaskItem?> GetTask(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }
    public async Task<TaskItem> AddTask(TaskItem task)
    {
        task.CreatedAt = DateTimeOffset.UtcNow;
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }
    public async Task<TaskItem> UpdateTask(int taskId, TaskItem task)
    {
       var oldTask = _context.Tasks.FirstOrDefault(t=> t.Id == taskId);
         if (oldTask == null)
         {
              throw new Exception("Task not found");
         }
         if (task.Description != null)
         {
             oldTask.Description = task.Description;
         }
         if (task.IsCompleted != oldTask.IsCompleted)
         {
             oldTask.IsCompleted = task.IsCompleted;
         }
         if (task.Priority != null)
         {
             oldTask.Priority = task.Priority;
         }
         if (task.UserId != null)
         {
             oldTask.UserId = task.UserId;
         }
         await _context.SaveChangesAsync();
         return oldTask;
    }
    public async Task<TaskItem> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return null!;
        }
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return task;
    }
}
