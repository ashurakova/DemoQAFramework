using Lecture13.Common.WebElements;
using OpenQA.Selenium;

namespace Lecture13.PageObjects.DemoQA.Elements
{
    // inherits BaseDemoQAPage
    public class TextBoxPage : BaseDemoQAPage
    {
        // private elements
        private MyWebElement _fullNameTextBox = new MyWebElement(By.Id("userName"));
        private MyWebElement _emailTextBox = new MyWebElement(By.Id("userEmail"));
        private MyWebElement _submitButton = new MyWebElement(By.Id("submit"));
        private MyWebElement _nameResult = new MyWebElement(By.Id("name"));
        private MyWebElement _emailResult = new MyWebElement(By.Id("email"));

        // public methods to incapsulate intaractions with elements
        public void EnterFullName(string fullName) => _fullNameTextBox.SendKeys(fullName);

        public void EnterEmail(string email) => _emailTextBox.SendKeys(email);

        public void ClickSubmitButton() => _submitButton.Click();

        public string GetNameResultText() => _nameResult.Text;

        public string GetEmailResultText() => _emailResult.Text;
    }
}
