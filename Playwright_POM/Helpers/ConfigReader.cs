using Newtonsoft.Json;

public class ConfigReader
{
    public static dynamic ReadConfig()
    {
        string configFile = File.ReadAllText("Config/appsettings.json");
        return JsonConvert.DeserializeObject<dynamic>(configFile);
    }
}
