using Microsoft.AspNetCore.Identity;
namespace taskaloo.Models;

public class User: IdentityUser
{
    public bool SendNotifications { get; set; }
    public int? PriorityThreshold { get; set; }
    public string? DailyorWeekly { get; set; }
    public string? TimeZone { get; set; }
    public int? DailyHour { get; set; }
    public int? DayOfWeek { get; set; }
}