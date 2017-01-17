using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SunriseMobileX.UiTest.Screens
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "loginUsernameTextbox")]
        [CacheLookup]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "loginPasswordTextbox")]
        [CacheLookup]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "loginButton")]
        [CacheLookup]
        public IWebElement LoginBtn { get; set; }
    }
}
