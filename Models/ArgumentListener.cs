namespace ModuleAPI.Models;

public class ArgumentListener
{

    private string[] Arguments;

    public ArgumentListener(string[] args)
    {
        Arguments = args;
        if (args.Length < 2)
        {
            System.Environment.Exit(-1);
        }
    }

    public string GetKernelHost()
    {
        return Arguments[0];
    }

    public string GetModuleKey()
    {
        return Arguments[1];
    }
}