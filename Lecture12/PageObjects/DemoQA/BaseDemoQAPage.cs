using Lecture13.Common.WebElements;
using OpenQA.Selenium;

namespace Lecture13.PageObjects.DemoQA
{
    public class BaseDemoQAPage : BasePage
    {
        // method to expand category
        public void ExpandCategory(string categoryName)
        {
            // base part of "element-group" item
            var elementGroupXpathLocator = $"//*[@class='element-group' and .//text()='{categoryName}']";

            // element with "collapse" class. When this one is expanded class contains "show". This one is need to check if element is collapsed or expanded
            var elementListWithCollapseClass = new MyWebElement(By.XPath($"{elementGroupXpathLocator}//div[contains(@class,'collapse')]"));

            // element to click if "element-group" is collapsed to expand it
            var groupHeader = new MyWebElement(By.XPath($"{elementGroupXpathLocator}//*[@class='group-header']"));

            // click groupHeader if "element-group" is collapsed
            if (!elementListWithCollapseClass.GetValueOfClassAttribute().Contains("show"))
            {
                groupHeader.Click();
            }
        }
    }
}
