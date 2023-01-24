using Lecture13.Data.Enums;
using Microsoft.Extensions.Configuration;

namespace Lecture13.Data
{
    // to make it parallelizable you have to remove static 
    public static class TestSettings
    {
        public static Browsers Browser { get; set; }
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
        public static string DemoQATextBoxPageUrl { get; set; }

        // after Build() it will contain context of our .json file
        public static IConfiguration TestConfiguration { get; } = new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();

        static TestSettings()
        {
            // easy way to get value from .json file by keys like these
            Enum.TryParse(TestConfiguration["Common:Browser"], out Browsers browser);
            Browser = browser;
            UserName = TestConfiguration["TestData:UserName"];
            UserEmail = TestConfiguration["TestData:UserEmail"];
            DemoQATextBoxPageUrl = TestConfiguration["Common:DemoQAUrls:TextBoxPage"];
        }
    }
}
