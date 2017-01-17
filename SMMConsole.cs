using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SunriseMobileX.UiTest.Framework;
using SunriseMobileX.UiTest.Framework.TestConfiguration;
using System;

namespace SunriseMobileX.UiTest.Screens
{
    public class SMMConsole
    {
        private IWebDriver driver;

        /// <summary>
        /// Open browser and load SMMC URL
        /// </summary>
        public SMMConsole()
        {
            //https://chromedriver.storage.googleapis.com/index.html?path=2.27/
            driver = new ChromeDriver();

            //get URL            
            HostConfiguration hostConfiguration = new HostConfiguration();
            string envUrl = hostConfiguration.HwsUrl;
            if (envUrl.Contains("163_"))
                driver.Url = "https://0.0.0.0/mobqa163_smmc";
            else if (envUrl.Contains("153_"))
                driver.Url = "https://0.0.0.0/mobaut153_smmc";
            else
                throw new Exception("The following environment is not supported. Please add it to SMMConsole. URL: " + envUrl);
        }

        /// <summary>
        /// Login to SMMC
        /// </summary>
        /// <param name="user">user name</param>
        /// <param name="pass">password</param>
        /// <returns>SMMConsole</returns>
        public SMMConsole Login(string user, string pass)
        {
            //submit login form
            var loginPage = new LoginPage(driver);
            loginPage.UserName.SendKeys(user);
            loginPage.Password.SendKeys(pass);
            loginPage.LoginBtn.Click();
            //wait till tabs will be visible
            WaitForVisibility(By.Id("contentTabs"), 30);
            return this;
        }

        /// <summary>
        /// Select tab in SMMC - DO NOT USE
        /// </summary>
        /// <param name="tab">console tab</param>
        /// <returns>TabPage</returns>
        [Obsolete]
        public TabPage SelectTab(ConsoleTab tab)
        {
            switch (tab)
            {
                case ConsoleTab.Users:
                    {
                        var usersPage = new UsersPage(driver);
                        usersPage.Tab.Click();
                        return usersPage;
                    }
                case ConsoleTab.Config:
                    {
                        var configPage = new ConfigPage(driver);
                        configPage.Tab.Click();
                        return configPage;
                    }
            }

            throw new Exception(tab + " is not supported");
        }

        /// <summary>
        /// Select Config tab
        /// </summary>
        /// <returns>ConfigPage</returns>
        public ConfigPage SelectConfigTab()
        {
            var configPage = new ConfigPage(driver);
            configPage.Tab.Click();
            return configPage;
        }

        /// <summary>
        /// Close browser
        /// </summary>
        public void Close()
        {
            driver.Close();
        }

        /// <summary>
        /// Wait till element will be visible
        /// </summary>
        /// <param name="by">search By</param>
        /// <param name="seconds">timeout in seconds</param>
        public void WaitForVisibility(By by, int seconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

        public enum ConsoleTab
        {
            [EnumValue("contentTab1")]
            Dashboard,
            [EnumValue("contentTab2")]
            Users,
            [EnumValue("contentTab3")]
            Config,
            [EnumValue("contentTab4")]
            Diagnostic
        }
    }
}
