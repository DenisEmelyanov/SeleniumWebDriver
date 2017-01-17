using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SunriseMobileX.UiTest.Screens
{
    public class UsersPage : TabPage
    {
        public UsersPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "contentTab2")]
        [CacheLookup]
        public IWebElement Tab { get; set; }
    }
}
