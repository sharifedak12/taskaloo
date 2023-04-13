using Microsoft.EntityFrameworkCore;
using taskaloo.Data;
using taskaloo.Models;

namespace taskaloo.Repositories;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetTasksByUser(Guid userId);
    Task<TaskItem?> GetTask(int id);
    Task<TaskItem> AddTask(TaskItem task);
    Task<TaskItem> UpdateTask(TaskItem task);
    Task<TaskItem> DeleteTask(int id);
}
public class TaskRespository : ITaskRepository
{
    private readonly BackendContext _context;
    public TaskRespository(BackendContext context)
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
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }
    public async Task<TaskItem> UpdateTask(TaskItem task)
    {
        _context.Entry(task).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return task;
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
