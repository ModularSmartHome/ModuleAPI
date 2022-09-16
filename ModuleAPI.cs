using ModuleAPI.Models;

namespace ModuleAPI;

public class ModuleAPI
{
    private WebApplicationBuilder WebAppBuilder;

    public ModuleAPI(string[] args)
    {
        WebAppBuilder = WebApplication.CreateBuilder(args);
        WebAppBuilder.Services.AddControllers();
        WebAppBuilder.Services.AddEndpointsApiExplorer();
        WebAppBuilder.Services.AddSwaggerGen();
    }

    public ModuleAPI SetActionHandler(IActionHandler actionHandler)
    {
        WebAppBuilder.Services.AddSingleton<IActionHandler>(sp => actionHandler);
        return this;
    }

    public void RunServer()
    {
        var app = WebAppBuilder.Build();
        app.MapControllers();
        app.Run();
    }


}