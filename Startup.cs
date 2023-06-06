using Microsoft.EntityFrameworkCore;
using taskaloo.Data;

namespace taskaloo;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddEntityFrameworkNpgsql().AddDbContext<BackendContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DbContext")));
        
    }
    
}