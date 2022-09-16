﻿using DefaultNamespace;
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
        WebAppBuilder.Services.AddSingleton<ArgumentListener>(sp => new ArgumentListener(args));
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

    public void RunServer()
    {
        DefineApplicationPort();
        var app = WebAppBuilder.Build();
        app.MapControllers();
        app.Run();
    }

    private void DefineApplicationPort()
    {
        var tcpLookup = new TcpPortLookup();
        var freePort =tcpLookup.GetUnusedPort();
        WebAppBuilder.WebHost.UseUrls("http://localhost:" + freePort);
    }


}