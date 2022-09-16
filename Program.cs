using ModuleAPI.Example;

var module = new ModuleAPI.ModuleAPI(args);
module.SetActionHandler(new ExampleActionHandler());
module.RunServer();

/*
ModuleServer:
/getStatus
/shutdown
/enable
/disable
/idle
 */
