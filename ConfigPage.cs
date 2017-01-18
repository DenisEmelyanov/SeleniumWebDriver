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

        #region *** Security section ***
        #region Allow credentials to be saved on device
        public bool AllowCredentialsToBeSavedOnDevice
        {
            get
            {
                return AllowSaveCredentialsYes.Selected;
            }

            set
            {
                if (value)
                    AllowSaveCredentialsYes.Click();
                else
                    AllowSaveCredentialsNo.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "allowSaveCredentialsYes")]
        [CacheLookup]
        private IWebElement AllowSaveCredentialsYes { get; set; }

        [FindsBy(How = How.Id, Using = "allowSaveCredentialsNo")]
        [CacheLookup]
        private IWebElement AllowSaveCredentialsNo { get; set; }
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
                return PasscodeEnabledYes.Selected;
            }

            set
            {
                if (value)
                    PasscodeEnabledYes.Click();
                else
                    PasscodeEnabledNo.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "passcodeEnabledYes")]
        [CacheLookup]
        private IWebElement PasscodeEnabledYes { get; set; }

        [FindsBy(How = How.Id, Using = "passcodeEnabledNo")]
        [CacheLookup]
        private IWebElement PasscodeEnabledNo { get; set; }
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

        #region *** Client Features section ***
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

        #region SuperBill
        public bool SuperBill
        {
            get
            {
                return SuperbillRadioButtonOn.Selected;
            }

            set
            {
                if (value)
                    SuperbillRadioButtonOn.Click();
                else
                    SuperbillRadioButtonOff.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "superbillRadioButtonOn")]
        [CacheLookup]
        private IWebElement SuperbillRadioButtonOn { get; set; }

        [FindsBy(How = How.Id, Using = "superbillRadioButtonOff")]
        [CacheLookup]
        private IWebElement SuperbillRadioButtonOff { get; set; }
        #endregion

        #region Order Entry
        public bool OrderEntry
        {
            get
            {
                return OrderEntryEnabledRadioButtonOn.Selected;
            }

            set
            {
                if (value)
                    OrderEntryEnabledRadioButtonOn.Click();
                else
                    OrderEntryEnabledRadioButtonOff.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "orderEntryEnabledRadioButtonOn")]
        [CacheLookup]
        private IWebElement OrderEntryEnabledRadioButtonOn { get; set; }

        [FindsBy(How = How.Id, Using = "orderEntryEnabledRadioButtonOff")]
        [CacheLookup]
        private IWebElement OrderEntryEnabledRadioButtonOff { get; set; }
        #endregion

        #region Reason for Exam Codes
        public string ReasonForExamCodes
        {
            get
            {
                return ReasonForExamCodesField.GetAttribute("value");
            }
            set
            {
                ReasonForExamCodesField.Clear();
                ReasonForExamCodesField.SendKeys(value);
            }
        }
        [FindsBy(How = How.Id, Using = "reasonForExamCodesTextbox")]
        [CacheLookup]
        private IWebElement ReasonForExamCodesField { get; set; }
        #endregion

        #region AllowOrdersetsInOrderEntry
        public bool AllowOrdersetsInOrderEntry
        {
            get
            {
                return OrdersetsEnabledRadioButtonOn.Selected;
            }

            set
            {
                if (value)
                    OrdersetsEnabledRadioButtonOn.Click();
                else
                    OrdersetsEnabledRadioButtonOff.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "ordersetsEnabledRadioButtonOn")]
        [CacheLookup]
        private IWebElement OrdersetsEnabledRadioButtonOn { get; set; }

        [FindsBy(How = How.Id, Using = "ordersetsEnabledRadioButtonOff")]
        [CacheLookup]
        private IWebElement OrdersetsEnabledRadioButtonOff { get; set; }
        #endregion

        #region Flowsheets
        public bool Flowsheets
        {
            get
            {
                return FlowsheetsEnabledRadioButtonOn.Selected;
            }

            set
            {
                if (value)
                    FlowsheetsEnabledRadioButtonOn.Click();
                else
                    FlowsheetsEnabledRadioButtonOff.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "FlowsheetsEnabledRadioButtonOn")]
        [CacheLookup]
        private IWebElement FlowsheetsEnabledRadioButtonOn { get; set; }

        [FindsBy(How = How.Id, Using = "FlowsheetsEnabledRadioButtonOff")]
        [CacheLookup]
        private IWebElement FlowsheetsEnabledRadioButtonOff { get; set; }
        #endregion

        #region 2-Factor Authentication
        public bool TwoFactorAuthentication
        {
            get
            {
                return TwoFactorAuthenticationEnabledRadioButtonOn.Selected;
            }

            set
            {
                if (value)
                    TwoFactorAuthenticationEnabledRadioButtonOn.Click();
                else
                    TwoFactorAuthenticationEnabledRadioButtonOff.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "TwoFactorAuthenticationEnabledRadioButtonOn")]
        [CacheLookup]
        private IWebElement TwoFactorAuthenticationEnabledRadioButtonOn { get; set; }

        [FindsBy(How = How.Id, Using = "TwoFactorAuthenticationEnabledRadioButtonOff")]
        [CacheLookup]
        private IWebElement TwoFactorAuthenticationEnabledRadioButtonOff { get; set; }
        #endregion

        #region Progress Note
        public bool ProgressNote
        {
            get
            {
                return ProgressNoteEnabledRadioButtonOn.Selected;
            }

            set
            {
                if (value)
                    ProgressNoteEnabledRadioButtonOn.Click();
                else
                    ProgressNoteEnabledRadioButtonOff.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "progressNoteEnabledRadioButtonOn")]
        [CacheLookup]
        private IWebElement ProgressNoteEnabledRadioButtonOn { get; set; }

        [FindsBy(How = How.Id, Using = "progressNoteEnabledRadioButtonOff")]
        [CacheLookup]
        private IWebElement ProgressNoteEnabledRadioButtonOff { get; set; }
        #endregion

        #region Progress Note Name
        public string ProgressNoteName
        {
            get
            {
                return ProgressNoteNameField.GetAttribute("value");
            }
            set
            {
                ProgressNoteNameField.Clear();
                ProgressNoteNameField.SendKeys(value);
            }
        }
        [FindsBy(How = How.Id, Using = "progressNoteNameTextbox")]
        [CacheLookup]
        private IWebElement ProgressNoteNameField { get; set; }
        #endregion

        #region Unsubmitted Notes
        public bool UnsubmittedNotes
        {
            get
            {
                return UnsubmittedNotesEnabledRadioButtonOn.Selected;
            }

            set
            {
                if (value)
                    UnsubmittedNotesEnabledRadioButtonOn.Click();
                else
                    UnsubmittedNotesEnabledRadioButtonOff.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "unsubmittedNotesEnabledRadioButtonOn")]
        [CacheLookup]
        private IWebElement UnsubmittedNotesEnabledRadioButtonOn { get; set; }

        [FindsBy(How = How.Id, Using = "unsubmittedNotesEnabledRadioButtonOff")]
        [CacheLookup]
        private IWebElement UnsubmittedNotesEnabledRadioButtonOff { get; set; }
        #endregion

        #region Add Problems from Progress Note
        public bool AddProblemsFromProgressNote
        {
            get
            {
                return AddProblemsFromProgressNotesEnabledRadioButtonOn.Selected;
            }

            set
            {
                if (value)
                    AddProblemsFromProgressNotesEnabledRadioButtonOn.Click();
                else
                    AddProblemsFromProgressNotesEnabledRadioButtonOff.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "addProblemsFromProgressNotesEnabledRadioButtonOn")]
        [CacheLookup]
        private IWebElement AddProblemsFromProgressNotesEnabledRadioButtonOn { get; set; }

        [FindsBy(How = How.Id, Using = "addProblemsFromProgressNotesEnabledRadioButtonOff")]
        [CacheLookup]
        private IWebElement AddProblemsFromProgressNotesEnabledRadioButtonOff { get; set; }
        #endregion

        #region Progress Note Health Issue Type
        public string ProgressNoteHealthIssueType
        {
            get
            {
                return ProgressNoteHealthIssueTypeField.GetAttribute("value");
            }
            set
            {
                ProgressNoteHealthIssueTypeField.Clear();
                ProgressNoteHealthIssueTypeField.SendKeys(value);
            }
        }
        [FindsBy(How = How.Id, Using = "progressNoteHealthIssueTextbox")]
        [CacheLookup]
        private IWebElement ProgressNoteHealthIssueTypeField { get; set; }
        #endregion

        #region Progress Note Coding Scheme(s)
        public string ProgressNoteCodingScheme
        {
            get
            {
                return ProgressNoteCodingSchemeField.GetAttribute("value");
            }
            set
            {
                ProgressNoteCodingSchemeField.Clear();
                ProgressNoteCodingSchemeField.SendKeys(value);
            }
        }
        [FindsBy(How = How.Id, Using = "progressNoteCodingSchemeTextbox")]
        [CacheLookup]
        private IWebElement ProgressNoteCodingSchemeField { get; set; }
        #endregion

        #region Display Result Images
        public bool DisplayResultImages
        {
            get
            {
                return ResultImagesEnabledRadioButtonOn.Selected;
            }

            set
            {
                if (value)
                    ResultImagesEnabledRadioButtonOn.Click();
                else
                    ResultImagesEnabledRadioButtonOff.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "resultImagesEnabledRadioButtonOn")]
        [CacheLookup]
        private IWebElement ResultImagesEnabledRadioButtonOn { get; set; }

        [FindsBy(How = How.Id, Using = "resultImagesEnabledRadioButtonOff")]
        [CacheLookup]
        private IWebElement ResultImagesEnabledRadioButtonOff { get; set; }
        #endregion

        #region Diagnostic Report Impression Label(s)
        public string DiagnosticReportImpressionLabel
        {
            get
            {
                return DiagnosticImpressionTagTextbox.GetAttribute("value");
            }
            set
            {
                DiagnosticImpressionTagTextbox.Clear();
                DiagnosticImpressionTagTextbox.SendKeys(value);
            }
        }
        [FindsBy(How = How.Id, Using = "diagnosticImpressionTagTextbox")]
        [CacheLookup]
        private IWebElement DiagnosticImpressionTagTextbox { get; set; }
        #endregion

        #region Context Sharing
        public bool ContextSharing
        {
            get
            {
                return ContextSharingEnabledRadioButtonOn.Selected;
            }

            set
            {
                if (value)
                    ContextSharingEnabledRadioButtonOn.Click();
                else
                    ContextSharingEnabledRadioButtonOff.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "contextSharingEnabledRadioButtonOn")]
        [CacheLookup]
        private IWebElement ContextSharingEnabledRadioButtonOn { get; set; }

        [FindsBy(How = How.Id, Using = "contextSharingEnabledRadioButtonOff")]
        [CacheLookup]
        private IWebElement ContextSharingEnabledRadioButtonOff { get; set; }
        #endregion

        #region ResolutionMD Integration
        public bool ResolutionMDIntegration
        {
            get
            {
                return ResolutionMDIntegrationEnabledRadioButtonOn.Selected;
            }

            set
            {
                if (value)
                    ResolutionMDIntegrationEnabledRadioButtonOn.Click();
                else
                    ResolutionMDIntegrationEnabledRadioButtonOff.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "resolutionMDIntegrationEnabledRadioButtonOn")]
        [CacheLookup]
        private IWebElement ResolutionMDIntegrationEnabledRadioButtonOn { get; set; }

        [FindsBy(How = How.Id, Using = "resolutionMDIntegrationEnabledRadioButtonOff")]
        [CacheLookup]
        private IWebElement ResolutionMDIntegrationEnabledRadioButtonOff { get; set; }
        #endregion

        #region ResolutionMD URL
        public string ResolutionMDURL
        {
            get
            {
                return resolutionMDUrlTextbox.GetAttribute("value");
            }
            set
            {
                resolutionMDUrlTextbox.Clear();
                resolutionMDUrlTextbox.SendKeys(value);
            }
        }
        [FindsBy(How = How.Id, Using = "resolutionMDUrlTextbox")]
        [CacheLookup]
        private IWebElement resolutionMDUrlTextbox { get; set; }
        #endregion
        #endregion

        #region *** International Settings section ***
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
