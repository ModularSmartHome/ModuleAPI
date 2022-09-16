namespace ModuleAPI.Models;

public class ModuleInfo
{
    public string ModuleName { get; set; }
    
    public string ModuleVersion { get; set; }

    public ModuleInfo(string name, string version)
    {
        ModuleName = name;
        ModuleVersion = version;
    }
}