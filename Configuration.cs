using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace TFL
{
    public class Configuration
    {
        private static IConfigurationRoot? _configuration;
        public static IConfigurationRoot AppConfig
        {
            get => _configuration!;
            set => _configuration = value;
        }

        public Configuration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Assembly.GetExecutingAssembly().Location)!.Parent!.Parent!.Parent!.FullName)
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            AppConfig = builder.Build();
        }

        public string getConfigValue(string key)
        {
            return Environment.GetEnvironmentVariable(key) ?? AppConfig[key]!;
        }

        public string BaseUrl => string.Format(getConfigValue("baseUrl"));
        public string Browser => string.Format(getConfigValue("browser"));
        public bool ExtentReport => (bool.Parse(getConfigValue("isReport")));
    }   
}