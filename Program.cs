using ModuleAPI.Example;
using ModuleAPI.Models;
using ModuleAPI.Shared;

var module = new ModuleAPI.ModuleAPI(args);
module.SetActionHandler(new ExampleActionHandler())
    .SetModuleInfo(new ModuleInfo("Test", "v1.0.0"))
    .SetDatabaseContext<AbstractDatabaseContext>();
module.RunServer();
