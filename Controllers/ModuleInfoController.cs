using Microsoft.AspNetCore.Mvc;
using ModuleAPI.Models;

namespace ModuleAPI.Controllers;

[ApiController]
public class ModuleInfoController : ControllerBase
{

    private readonly ModuleInfo Info;

    public ModuleInfoController(ModuleInfo info)
    {
        Info = info;
    }

    [HttpGet("/getModuleInfo")]
    public ActionResult<ModuleInfo> GetModuleInfo()
    {
        return Ok(Info);
    }

}