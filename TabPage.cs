using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SunriseMobileX.UiTest.Screens
{
    public class TabPage
    {
        private IWebDriver driver;

        public TabPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }

            set
            {
                driver = value;
            }
        }
    }
}
