using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SunriseMobileX.UiTest.Screens
{
    public class TabPage
    {
        public IWebDriver Driver { get; set; }

        public TabPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }      
    }
}
