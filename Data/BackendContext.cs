using Microsoft.EntityFrameworkCore;
using taskaloo.Models;

namespace taskaloo.Data;

public class BackendContext :DbContext
{
    public BackendContext(DbContextOptions<BackendContext> options) : base(options)
    {
    }

    public DbSet<TaskItem?> Tasks { get; set; }
}
