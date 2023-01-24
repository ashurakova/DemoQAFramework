using Lecture13.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using System.Collections.Concurrent;

namespace Lecture13.Common.Drivers
{
    public class WebDriverFactory
    {
        private static readonly ConcurrentDictionary<string, IWebDriver> DriverCollection = new(); // collection created to isolate threads for possible parallelization

        public static IWebDriver Driver
        {
            get
            {
                if (!DriverCollection.Keys.Contains(TestContextValues.ExecutableClassName)) // if driver is not initialized yet we do it
                {
                    InitializeDriver();
                }

                return DriverCollection.First(pair => pair.Key == TestContextValues.ExecutableClassName).Value; // return driver for needed test class
            }

            private set => DriverCollection.TryAdd(TestContextValues.ExecutableClassName, value); // new driver will be assigned only if DriverCollection doesn't contains value by this key
        }

        public static Actions Actions => new Actions(Driver); // return instance of Actions

        public static IJavaScriptExecutor JavaScriptExecutor => (IJavaScriptExecutor)Driver; // return instance of IJavaScriptExecutor

        public static void QuitDriver() => Driver.Quit();

        private static void InitializeDriver() // initialization method for driver
        {
            Driver = TestSettings.Browser switch
            {
                Data.Enums.Browsers.Chrome => new ChromeDriver(),
                Data.Enums.Browsers.Edge => new EdgeDriver(),
                _ => throw new InvalidOperationException(),
            };

            Driver.Manage().Window.Maximize();
        }
    }
}
