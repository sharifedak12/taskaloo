namespace taskaloo.Models;

public class User
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public bool SendNotifications { get; set; }
}