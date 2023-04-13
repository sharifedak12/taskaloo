namespace taskaloo.Models;

public class TaskItem
{
    public DateTimeOffset CreatedAt { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int Priority { get; set; }
}