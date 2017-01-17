using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SunriseMobileX.UiTest.Framework;
using System;
using System.Threading;

namespace SunriseMobileX.UiTest.Screens
{
    public class ConfigPage : TabPage
    {
        public ConfigPage(IWebDriver driver) : base(driver)
        {
            //wait untill AppInactivityTimeout will have value
            int maxAttempts = 60;
            while(string.IsNullOrEmpty(AppInactivityTimeoutField.GetAttribute("value")) && maxAttempts > 0)
            {
                Thread.Sleep(1000);
                maxAttempts--;
            }
        }

        [FindsBy(How = How.Id, Using = "contentTab3")]
        [CacheLookup]
        public IWebElement Tab { get; set; }

        [FindsBy(How = How.LinkText, Using = "Save All Changes")]
        [CacheLookup]
        private IWebElement SaveAllChanges { get; set; }

        /// <summary>
        /// Save settings change on Config tab
        /// </summary>
        public void SaveChanges()
        {
            SaveAllChanges.Click();
            //dismiss pop up dialog
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy((By.Id("notifyUserOKButton"))));
            Driver.FindElement(By.Id("notifyUserOKButton")).Click();
        }

        #region Security section

        #region Allow credentials to be saved on device
        public bool AllowCredentialsToBeSavedOnDevice
        {
            get
            {
                return AllowCredentialsToBeSavedOnDeviceYes.Selected;
            }

            set
            {
                if (value)
                    AllowCredentialsToBeSavedOnDeviceYes.Click();
                else
                    AllowCredentialsToBeSavedOnDeviceNo.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "allowSaveCredentialsYes")]
        [CacheLookup]
        private IWebElement AllowCredentialsToBeSavedOnDeviceYes { get; set; }

        [FindsBy(How = How.Id, Using = "allowSaveCredentialsNo")]
        [CacheLookup]
        private IWebElement AllowCredentialsToBeSavedOnDeviceNo { get; set; }
        #endregion

        #region Time Between Logons
        public int TimeBetweenLogons
        {
            get
            {
                return int.Parse(TimeBetweenLogonsField.GetAttribute("value"));
            }
            set
            {
                TimeBetweenLogonsField.Clear();
                TimeBetweenLogonsField.SendKeys(value.ToString());
            }
        }
        [FindsBy(How = How.Id, Using = "hoursBetweenLoginsTextbox")]
        [CacheLookup]
        private IWebElement TimeBetweenLogonsField { get; set; }
        #endregion

        #region App Inactivity Timeout
        public int AppInactivityTimeout
        {
            get
            {
                return int.Parse(AppInactivityTimeoutField.GetAttribute("value"));
            }
            set
            {
                AppInactivityTimeoutField.Clear();
                AppInactivityTimeoutField.SendKeys(value.ToString());
            }
        }
        [FindsBy(How = How.Id, Using = "appSuspendedCredentialExpirationSecondsTextbox")]
        [CacheLookup]
        private IWebElement AppInactivityTimeoutField { get; set; }
        #endregion

        #region Passcodes Enabled
        public bool PasscodeEnabled
        {
            get
            {
                return PasscodesEnabledYes.Selected;
            }

            set
            {
                if (value)
                    PasscodesEnabledYes.Click();
                else
                    PasscodesEnabledNo.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "passcodeEnabledYes")]
        [CacheLookup]
        private IWebElement PasscodesEnabledYes { get; set; }

        [FindsBy(How = How.Id, Using = "passcodeEnabledNo")]
        [CacheLookup]
        private IWebElement PasscodesEnabledNo { get; set; }
        #endregion

        #region Sunrise Mobile Security Right
        public string SunriseMobileSecurityRight
        {
            get
            {
                return SunriseMobileSecurityRightField.GetAttribute("value");
            }
            set
            {
                SunriseMobileSecurityRightField.Clear();
                SunriseMobileSecurityRightField.SendKeys(value);
            }
        }
        [FindsBy(How = How.Id, Using = "accessSecurityRightTextbox")]
        [CacheLookup]
        private IWebElement SunriseMobileSecurityRightField { get; set; }
        #endregion

        #endregion

        #region Client Features section
        #region Patient Photos
        public PatientPhotosOption PatientPhotos
        {
            get
            {
                if (PhotosOptionRadioButtonNoPhotos.Selected)
                    return PatientPhotosOption.NoPhotos;
                else if (PhotosOptionRadioButtonViewOnly.Selected)
                    return PatientPhotosOption.ViewOnly;
                else if (PhotosOptionRadioButtonViewAndTake.Selected)
                    return PatientPhotosOption.ViewAndTake;
                throw new Exception("No Patient Photos radio button is selected");
            }

            set
            {
                switch (value)
                {
                    case PatientPhotosOption.NoPhotos:
                        {
                            PhotosOptionRadioButtonNoPhotos.Click();
                            break;
                        }
                    case PatientPhotosOption.ViewOnly:
                        {
                            PhotosOptionRadioButtonViewOnly.Click();
                            break;
                        }
                    case PatientPhotosOption.ViewAndTake:
                        {
                            PhotosOptionRadioButtonViewAndTake.Click();
                            break;
                        }
                }
            }
        }

        [FindsBy(How = How.Id, Using = "photosOptionRadioButtonNoPhotos")]
        [CacheLookup]
        private IWebElement PhotosOptionRadioButtonNoPhotos { get; set; }

        [FindsBy(How = How.Id, Using = "photosOptionRadioButtonViewOnly")]
        [CacheLookup]
        private IWebElement PhotosOptionRadioButtonViewOnly { get; set; }

        [FindsBy(How = How.Id, Using = "photosOptionRadioButtonViewEdit")]
        [CacheLookup]
        private IWebElement PhotosOptionRadioButtonViewAndTake { get; set; }

        public enum PatientPhotosOption
        {
            NoPhotos, ViewOnly, ViewAndTake
        }
        #endregion

        #region Notify Me
        public bool NotifyMe
        {
            get
            {
                return NotifyMeRadioButtonOn.Selected;
            }

            set
            {
                if (value)
                    NotifyMeRadioButtonOn.Click();
                else
                    NotifyMeRadioButtonOff.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "notifyMeRadioButtonOn")]
        [CacheLookup]
        private IWebElement NotifyMeRadioButtonOn { get; set; }

        [FindsBy(How = How.Id, Using = "notifyMeRadioButtonOff")]
        [CacheLookup]
        private IWebElement NotifyMeRadioButtonOff { get; set; }
        #endregion
        #endregion

        #region International Settings section

        #region Patient Banner / List Selection
        public PatientBannerOption PatientBannerListSelection
        {
            get
            {
                SelectElement oSelect = new SelectElement(PatientBannerSelectionDropdown);
                var selectedOptionText = oSelect.SelectedOption.Text;
                if (selectedOptionText.Equals(PatientBannerOption.Standard.GetEnumValue()))
                    return PatientBannerOption.Standard;
                else if (selectedOptionText.Equals(PatientBannerOption.UK.GetEnumValue()))
                    return PatientBannerOption.UK;                
                throw new Exception("No Patient Banner / List option is selected");
            }
            set
            {
                SelectElement oSelect = new SelectElement(PatientBannerSelectionDropdown);
                oSelect.SelectByText(value.GetEnumValue());
            }
        }

        [FindsBy(How = How.Id, Using = "patientBannerSelectionDropdown")]
        [CacheLookup]
        private IWebElement PatientBannerSelectionDropdown {get; set; }

        public enum PatientBannerOption
        {
            [EnumValue("Standard")]
            Standard,
            [EnumValue("United Kingdom")]
            UK
        }
        #endregion

        #endregion
        }
}
