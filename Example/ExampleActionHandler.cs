using Microsoft.AspNetCore.Mvc;
using ModuleAPI.Models;

namespace ModuleAPI.Example;

public class ExampleActionHandler : IActionHandler
{
    public async Task<ActionResult> HandleAction(string action, object payload)
    {
        if (action == "test")
        {
            return new OkResult();
        }

        return new ForbidResult();
    }
}