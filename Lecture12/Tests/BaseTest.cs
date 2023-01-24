using Lecture13.Common.Drivers;
using NUnit.Framework;

namespace Lecture13.Tests
{
    public class BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // here you can add all necessary methods to call them once before all tests in descendant classes

            // just for example set custom size of window
            WebDriverFactory.Driver.Manage().Window.Size = new System.Drawing.Size(1200, 800);
        }

        [SetUp]
        public void SetUp()
        {
            // here you can add all necessary methods to call them before each test in descendant classes
        }

        [TearDown]
        public void TearDown()
        {
            // here you can add all necessary methods to call them after each test in descendant classes
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // here you can add all necessary methods to call them once after all tests in descendant classes
            WebDriverFactory.QuitDriver();
        }
    }
}
