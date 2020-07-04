using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace BuyBox.Data.Tests
{
    [SetUpFixture]
    public class ConfigurationLoader
    {
        private static IConfigurationRoot ConfigurationRoot { get; set; }

        public static string ConnectionString => ConfigurationRoot.GetConnectionString("BuyBoxDbContext");

        [OneTimeSetUp]
        public void ConfigurationBuilderTest()
        {
            ConfigurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}