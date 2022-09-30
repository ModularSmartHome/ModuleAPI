using Microsoft.AspNetCore.Mvc;
using ModuleAPI.Models;

namespace ModuleAPI.Controllers;

[ApiController]
public class ActionController : ControllerBase
{

    private readonly IActionHandler ActionHandler;

    public ActionController(IActionHandler actionHandler)
    {
        ActionHandler = actionHandler;
    }

    [HttpPost("/action")]
    public async Task<ActionResult> ExecuteAction([FromBody] ActionRequest request)
    {
        return await ActionHandler.HandleAction(request.Action, request.Payload);
    }

}