using System.Text;
using System.Text.Json;
using ModuleAPI.Models;

namespace ModuleAPI.Shared;

public class RestClient : HttpClient
{
    private ArgumentListener Args;

    public RestClient(ArgumentListener args)
    {
        Args = args;
    }

    public async Task<string> GetConnectionKey()
    {
        var key = Args.GetModuleKey();
        var data = new
        {
            accessKey = key
        };
        var json = JsonSerializer.Serialize(data);
        var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage response = await PostAsync(Args.GetKernelHost() + "/api/Module/GetDatabaseCredentials",
                stringContent);
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.InnerException?.Message);
            return "";
        }
    }

}