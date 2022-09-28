using Microsoft.AspNetCore.Mvc;
using ModularSmartHome.ModuleAPI.Models;

namespace ModularSmartHome.ModuleAPI.Controllers;

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