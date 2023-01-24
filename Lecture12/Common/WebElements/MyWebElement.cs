using Lecture13.Common.Drivers;
using Lecture13.Common.Extensions;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Lecture13.Common.WebElements
{
    // implement IWebElement
    public class MyWebElement : IWebElement
    {
        // property for locator to use it if needed
        protected By By { get; set; }

        // protected property for IWebElement returns value using IWebDriver extension method GetWebElementWhenExist
        // after that we can be sure that element is always is in a stable state and prevent possible exceptions
        protected IWebElement WebElement => WebDriverFactory.Driver.GetWebElementWhenExist(By);

        // start of default IWebElement properties
        public string TagName => WebElement.TagName;

        public string Text => WebElement.Text;

        public bool Enabled => WebElement.Enabled;

        public bool Selected => WebElement.Selected;

        public Point Location => WebElement.Location;

        public Size Size => WebElement.Size;

        public bool Displayed => WebElement.Displayed;
        // finish of default IWebElement properties

        // constructor to initizlize an instance of our custom element
        public MyWebElement(By by)
        {
            By = by;
        }

        // start of default IWebElement methods
        public void Clear() => WebElement.Clear();

        public void Click()
        {
            // here is a simple example why we need this wrapper
            try
            {
                WebElement.Click();
            }
            catch (ElementClickInterceptedException) // here we can handle if click is intercepted and scroll element into view
            {
                ScrollIntoView();
                WebElement.Click();
            }
        }

        public IWebElement FindElement(By by) => WebElement.FindElement(by);

        public ReadOnlyCollection<IWebElement> FindElements(By by) => WebElement.FindElements(by);

        public string GetAttribute(string attributeName) => WebElement.GetAttribute(attributeName);

        public string GetCssValue(string propertyName) => WebElement.GetCssValue(propertyName);

        public string GetDomAttribute(string attributeName) => WebElement.GetDomAttribute(attributeName);

        public string GetDomProperty(string propertyName) => WebElement.GetDomProperty(propertyName);

        public ISearchContext GetShadowRoot() => WebElement.GetShadowRoot();

        public void SendKeys(string text) => WebElement.SendKeys(text);

        public void Submit() => WebElement.Submit();
        // finish of default IWebElement methods

        // method to scroll element into view using JavaScript
        public void ScrollIntoView() => WebDriverFactory.JavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView()", WebElement);

        // method to get value of class attribute
        public string GetValueOfClassAttribute() => GetAttribute("class");
    }
}
