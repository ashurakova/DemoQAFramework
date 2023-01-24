using Lecture13.Common.Drivers;
using Lecture13.Data;
using Lecture13.Data.Constants;
using Lecture13.PageObjects.DemoQA.Elements;
using NUnit.Framework;

namespace Lecture13.Tests.DemoQA.Elements
{
    // inherits BaseTest
    public class TextBoxTests : BaseTest
    {
        [SetUp]
        public void TextBoxTestsSetUp()
        {
            // used GoToUrl(TestSettings.DemoQATextBoxPageUrl) to make sure that each test from TextBoxTests will start from initial state
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQATextBoxPageUrl);
        } 

        [Test]
        public void EnterFullNameAndEmailThenSubmit()
        {
            // initialize Page Object
            var textBoxPage = new TextBoxPage();

            // methods from BaseDemoQAPage just to show how it looks like
            // category names from constants
            textBoxPage.ExpandCategory(DemoQACategories.Elements);
            textBoxPage.ExpandCategory(DemoQACategories.Forms);

            // methods from page objects
            // test data from testsettings.json
            textBoxPage.EnterFullName(TestSettings.UserName);
            textBoxPage.EnterEmail(TestSettings.UserEmail);
            textBoxPage.ClickSubmitButton();
            var userNameResultText = textBoxPage.GetNameResultText();
            var userEmailResultText = textBoxPage.GetEmailResultText();

            Assert.AreEqual($"Name:{TestSettings.UserName}", userNameResultText);
            Assert.AreEqual($"Email:{TestSettings.UserEmail}", userEmailResultText);
        }
    }
}
