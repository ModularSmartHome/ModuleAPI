using ModuleAPI.Utility;
using ModuleAPI.Models;
using ModuleAPI.Shared;

namespace ModuleAPI;

public class ModuleAPI
{
    private WebApplicationBuilder WebAppBuilder;

    public ModuleAPI(string[] args)
    {
        WebAppBuilder = WebApplication.CreateBuilder(args);
        WebAppBuilder.Services.AddControllers();
        WebAppBuilder.Services.AddEndpointsApiExplorer();
        WebAppBuilder.Services.AddSingleton<ArgumentListener>(sp => new ArgumentListener(args));
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Started app");
    }

    public ModuleAPI SetActionHandler(IActionHandler actionHandler)
    {
        WebAppBuilder.Services.AddSingleton<IActionHandler>(sp => actionHandler);
        return this;
    }

    public ModuleAPI SetModuleInfo(ModuleInfo info)
    {
        WebAppBuilder.Services.AddSingleton<ModuleInfo>(sp => info);
        return this;
    }

    public ModuleAPI SetDatabaseContext<T>() where T : AbstractDatabaseContext
    {
        WebAppBuilder.Services.AddDbContext<T>();
        return this;
    }

    public void RunServer()
    {
        DefineApplicationPort();
        var app = WebAppBuilder.Build();
        CheckDatabaseConnection(app);
        app.MapControllers();
        app.Run();
    }

    private void DefineApplicationPort()
    {
        var tcpLookup = new TcpPortLookup();
        var freePort =tcpLookup.GetUnusedPort();
        WebAppBuilder.WebHost.UseUrls("http://localhost:" + freePort);
    }

    private void CheckDatabaseConnection(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        using (var db = scope.ServiceProvider.GetService<AbstractDatabaseContext>()!)
        {
            if (db.Database.CanConnect())
            {
                Console.WriteLine("Able to connect to database");
            }
            else
            {
                Console.WriteLine("Unable to connect to database");
            }
        }
    }


}