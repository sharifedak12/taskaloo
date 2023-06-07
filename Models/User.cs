namespace taskaloo.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string NormalizedEmail { get; set; }
    public string PasswordHash { get; set; }
    public bool SendNotifications { get; set; }
    public int? PriorityThreshold { get; set; }
    public string? DailyorWeekly { get; set; }
    public string? TimeZone { get; set; }
    public int? DailyHour { get; set; }
    public int? DayOfWeek { get; set; }
}