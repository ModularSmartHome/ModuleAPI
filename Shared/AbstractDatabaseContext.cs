using Microsoft.EntityFrameworkCore;
using ModuleAPI.Models;

namespace ModuleAPI.Shared;

public class AbstractDatabaseContext : DbContext
{
    protected ArgumentListener Arguments;
    
    public AbstractDatabaseContext(ArgumentListener argumentListener)
    {
        Arguments = argumentListener;
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var client = new RestClient(Arguments);
        var task = client.GetConnectionKey();
        var connectionString = task.GetAwaiter().GetResult();
        Console.WriteLine("ConnectionString: " + connectionString);
        optionsBuilder.UseNpgsql(connectionString);


        base.OnConfiguring(optionsBuilder);
    }

}