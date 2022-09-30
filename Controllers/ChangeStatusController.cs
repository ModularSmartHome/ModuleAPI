using Microsoft.AspNetCore.Mvc;

namespace ModuleAPI.Controllers;

[ApiController]
public class ChangeStatusController : ControllerBase
{

    [HttpPost("/shutdown")]
    public async Task<ActionResult> Shutdown()
    {
        Task.Delay(1000).ContinueWith(task =>
        {
            System.Environment.Exit(0);
        });
        return Ok();
    }
    
}