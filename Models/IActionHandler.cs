using Microsoft.AspNetCore.Mvc;

namespace ModularSmartHome.ModuleAPI.Models;

public interface IActionHandler
{
    public Task<ActionResult> HandleAction(string action, object payload);
}