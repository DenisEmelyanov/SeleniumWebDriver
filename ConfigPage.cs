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
        private SecuritySettings _securitySettings;
        private ClientFeaturesSettings _clientFeaturesSettings;
        private InternationalSettings _internationalSettings;
        private ClinicalSummaryConfigSettings _clinicalSummaryConfigSettings;
        private VitalsViewItems _vitalsViewItems;
        private NotifyServiceErrorSettings _notifyServiceErrorSettings;
        private OrderEntryOrdersetSettings _orderEntryOrdersetSettings;

        public ConfigPage(IWebDriver driver) : base(driver)
        {
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
        public SecuritySettings Security
        {
            get
            {
                //initialize if null
                if (_securitySettings == null)
                    _securitySettings = new SecuritySettings(Driver);
                return _securitySettings;
            }
        }

        public class SecuritySettings
        {
            public SecuritySettings(IWebDriver driver)
            {
                PageFactory.InitElements(driver, this);
            }

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
        }
        #endregion

        #region *** Client Features section ***

        public ClientFeaturesSettings ClientFeatures
        {
            get
            {
                //initialize if null
                if (_clientFeaturesSettings == null)
                    _clientFeaturesSettings = new ClientFeaturesSettings(Driver);
                return _clientFeaturesSettings;
            }
        }

        public class ClientFeaturesSettings
        {
            public ClientFeaturesSettings(IWebDriver driver)
            {
                PageFactory.InitElements(driver, this);
            }

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

            #region ResolutionMD Use PatientId
            public bool ResolutionMDUsePatientId
            {
                get
                {
                    return ResolutionMDUsePatientIdRadioButtonOn.Selected;
                }

                set
                {
                    if (value)
                        ResolutionMDUsePatientIdRadioButtonOn.Click();
                    else
                        ResolutionMDUsePatientIdRadioButtonOff.Click();
                }
            }

            [FindsBy(How = How.Id, Using = "resolutionMDUsePatientIdRadioButtonOn")]
            [CacheLookup]
            private IWebElement ResolutionMDUsePatientIdRadioButtonOn { get; set; }

            [FindsBy(How = How.Id, Using = "resolutionMDUsePatientIdRadioButtonOff")]
            [CacheLookup]
            private IWebElement ResolutionMDUsePatientIdRadioButtonOff { get; set; }
            #endregion

            #region ResolutionMD Remove Dashes From PatientId
            public bool ResolutionMDRemoveDashesFromPatientId
            {
                get
                {
                    return ResolutionMDRemoveDashesFromPatientIdRadioButtonOn.Selected;
                }

                set
                {
                    if (value)
                        ResolutionMDRemoveDashesFromPatientIdRadioButtonOn.Click();
                    else
                        ResolutionMDRemoveDashesFromPatientIdRadioButtonOff.Click();
                }
            }

            [FindsBy(How = How.Id, Using = "resolutionMDRemoveDashesFromPatientIdRadioButtonOn")]
            [CacheLookup]
            private IWebElement ResolutionMDRemoveDashesFromPatientIdRadioButtonOn { get; set; }

            [FindsBy(How = How.Id, Using = "resolutionMDRemoveDashesFromPatientIdRadioButtonOff")]
            [CacheLookup]
            private IWebElement ResolutionMDRemoveDashesFromPatientIdRadioButtonOff { get; set; }
            #endregion

            #region ResolutionMD Use Authentication Token
            public bool ResolutionMDUseAuthenticationToken
            {
                get
                {
                    return ResolutionMDUseAuthTokenRadioButtonOn.Selected;
                }

                set
                {
                    if (value)
                        ResolutionMDUseAuthTokenRadioButtonOn.Click();
                    else
                        ResolutionMDUseAuthTokenRadioButtonOff.Click();
                }
            }

            [FindsBy(How = How.Id, Using = "resolutionMDUseAuthTokenRadioButtonOn")]
            [CacheLookup]
            private IWebElement ResolutionMDUseAuthTokenRadioButtonOn { get; set; }

            [FindsBy(How = How.Id, Using = "resolutionMDUseAuthTokenRadioButtonOff")]
            [CacheLookup]
            private IWebElement ResolutionMDUseAuthTokenRadioButtonOff { get; set; }
            #endregion

            #region Ally
            public bool Ally
            {
                get
                {
                    return AllyEnabledRadioButtonOn.Selected;
                }

                set
                {
                    if (value)
                        AllyEnabledRadioButtonOn.Click();
                    else
                        AllyEnabledRadioButtonOff.Click();
                }
            }

            [FindsBy(How = How.Id, Using = "allyEnabledRadioButtonOn")]
            [CacheLookup]
            private IWebElement AllyEnabledRadioButtonOn { get; set; }

            [FindsBy(How = How.Id, Using = "allyEnabledRadioButtonOff")]
            [CacheLookup]
            private IWebElement AllyEnabledRadioButtonOff { get; set; }
            #endregion

            #region Negative Scan Outcome Audio Alerts
            public bool NegativeScanOutcomeAudioAlerts
            {
                get
                {
                    return ScannerAudioAlertsRadioButtonOn.Selected;
                }

                set
                {
                    if (value)
                        ScannerAudioAlertsRadioButtonOn.Click();
                    else
                        ScannerAudioAlertsRadioButtonOff.Click();
                }
            }

            [FindsBy(How = How.Id, Using = "scannerAudioAlertsRadioButtonOn")]
            [CacheLookup]
            private IWebElement ScannerAudioAlertsRadioButtonOn { get; set; }

            [FindsBy(How = How.Id, Using = "scannerAudioAlertsRadioButtonOff")]
            [CacheLookup]
            private IWebElement ScannerAudioAlertsRadioButtonOff { get; set; }
            #endregion
        }
        #endregion

        #region *** International Settings section ***
        public InternationalSettings International
        {
            get
            {
                //initialize if null
                if (_internationalSettings == null)
                    _internationalSettings = new InternationalSettings(Driver);
                return _internationalSettings;
            }
        }

        public class InternationalSettings
        {
            public InternationalSettings(IWebDriver driver)
            {
                PageFactory.InitElements(driver, this);
            }

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
            private IWebElement PatientBannerSelectionDropdown { get; set; }

            public enum PatientBannerOption
            {
                [EnumValue("Standard")]
                Standard,
                [EnumValue("United Kingdom")]
                UK
            }
            #endregion

            #region NHS Number ID Type
            public string NHSNumberIDType
            {
                get
                {
                    SelectElement oSelect = new SelectElement(NHSNumberIdTypeDropdown);
                    return oSelect.SelectedOption.Text;
                }
                set
                {
                    SelectElement oSelect = new SelectElement(NHSNumberIdTypeDropdown);
                    oSelect.SelectByText(value);
                }
            }

            [FindsBy(How = How.Id, Using = "nhsNumberIdTypeDropdown")]
            [CacheLookup]
            private IWebElement NHSNumberIdTypeDropdown { get; set; }
            #endregion
        }
        #endregion

        #region *** Clinical Summary Config Settings section ***
        public ClinicalSummaryConfigSettings ClinicalSummaryConfig
        {
            get
            {
                //initialize if null
                if (_clinicalSummaryConfigSettings == null)
                    _clinicalSummaryConfigSettings = new ClinicalSummaryConfigSettings(Driver);
                return _clinicalSummaryConfigSettings;
            }
        }

        public class ClinicalSummaryConfigSettings
        {
            public ClinicalSummaryConfigSettings(IWebDriver driver)
            {
                PageFactory.InitElements(driver, this);
            }

            #region Vitals View Name
            public string VitalsViewName
            {
                get
                {
                    SelectElement oSelect = new SelectElement(VitalsViewNameDropdown);
                    return oSelect.SelectedOption.Text;
                }
                set
                {
                    SelectElement oSelect = new SelectElement(VitalsViewNameDropdown);
                    oSelect.SelectByText(value);
                }
            }

            [FindsBy(How = How.Id, Using = "vitalsViewNameDropdown")]
            [CacheLookup]
            private IWebElement VitalsViewNameDropdown { get; set; }
            #endregion

            #region Fishbone Graphs Tile Name
            public string FishboneGraphsTileName
            {
                get
                {
                    SelectElement oSelect = new SelectElement(FishboneGraphsTileNameDropdown);
                    return oSelect.SelectedOption.Text;
                }
                set
                {
                    SelectElement oSelect = new SelectElement(FishboneGraphsTileNameDropdown);
                    oSelect.SelectByText(value);
                }
            }

            [FindsBy(How = How.Id, Using = "fishboneGraphsTileNameDropdown")]
            [CacheLookup]
            private IWebElement FishboneGraphsTileNameDropdown { get; set; }
            #endregion

            #region I&O Totals Tile Name
            public string IOTotalsTileName
            {
                get
                {
                    SelectElement oSelect = new SelectElement(IOTileNameDropdown);
                    return oSelect.SelectedOption.Text;
                }
                set
                {
                    SelectElement oSelect = new SelectElement(IOTileNameDropdown);
                    oSelect.SelectByText(value);
                }
            }

            [FindsBy(How = How.Id, Using = "ioTileNameDropdown")]
            [CacheLookup]
            private IWebElement IOTileNameDropdown { get; set; }
            #endregion

            #region I&O Histogram Tile Name
            public string IOHistogramTileName
            {
                get
                {
                    SelectElement oSelect = new SelectElement(IOHistogramTileNameDropdown);
                    return oSelect.SelectedOption.Text;
                }
                set
                {
                    SelectElement oSelect = new SelectElement(IOHistogramTileNameDropdown);
                    oSelect.SelectByText(value);
                }
            }

            [FindsBy(How = How.Id, Using = "ioHistogramTileNameDropdown")]
            [CacheLookup]
            private IWebElement IOHistogramTileNameDropdown { get; set; }
            #endregion

            #region Health Issues Tile Name
            public string HealthIssuesTileName
            {
                get
                {
                    SelectElement oSelect = new SelectElement(HealthIssuesTileNameDropdown);
                    return oSelect.SelectedOption.Text;
                }
                set
                {
                    SelectElement oSelect = new SelectElement(HealthIssuesTileNameDropdown);
                    oSelect.SelectByText(value);
                }
            }

            [FindsBy(How = How.Id, Using = "healthIssuesTileNameDropdown")]
            [CacheLookup]
            private IWebElement HealthIssuesTileNameDropdown { get; set; }
            #endregion
        }
        #endregion

        #region *** Observations Names for Vitals View section ***
        public VitalsViewItems VitalsView
        {
            get
            {
                //initialize if null
                if (_vitalsViewItems == null)
                    _vitalsViewItems = new VitalsViewItems(Driver);
                return _vitalsViewItems;
            }
        }

        public class VitalsViewItems
        {
            public VitalsViewItems(IWebDriver driver)
            {
                PageFactory.InitElements(driver, this);
            }

            #region Temp
            public string Temp
            {
                get
                {
                    return TempField.GetAttribute("value");
                }
                set
                {
                    TempField.Clear();
                    TempField.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "observationCellNames_temp")]
            [CacheLookup]
            private IWebElement TempField { get; set; }
            #endregion

            #region Height
            public string Height
            {
                get
                {
                    return HeightField.GetAttribute("value");
                }
                set
                {
                    HeightField.Clear();
                    HeightField.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "observationCellNames_height")]
            [CacheLookup]
            private IWebElement HeightField { get; set; }
            #endregion

            #region Height2
            public string Height2
            {
                get
                {
                    return HeightField2.GetAttribute("value");
                }
                set
                {
                    HeightField2.Clear();
                    HeightField2.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "observationCellNames_height2")]
            [CacheLookup]
            private IWebElement HeightField2 { get; set; }
            #endregion

            #region Weight
            public string Weight
            {
                get
                {
                    return WeightField.GetAttribute("value");
                }
                set
                {
                    WeightField.Clear();
                    WeightField.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "observationCellNames_weight")]
            [CacheLookup]
            private IWebElement WeightField { get; set; }
            #endregion

            #region BP Sys
            public string BPSys
            {
                get
                {
                    return BPSysField.GetAttribute("value");
                }
                set
                {
                    BPSysField.Clear();
                    BPSysField.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "observationCellNames_bpSys")]
            [CacheLookup]
            private IWebElement BPSysField { get; set; }
            #endregion

            #region BP Dias
            public string BPDias
            {
                get
                {
                    return BPDiasField.GetAttribute("value");
                }
                set
                {
                    BPDiasField.Clear();
                    BPDiasField.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "observationCellNames_bpDias")]
            [CacheLookup]
            private IWebElement BPDiasField { get; set; }
            #endregion

            #region Heart Rate
            public string HeartRate
            {
                get
                {
                    return HeartRateField.GetAttribute("value");
                }
                set
                {
                    HeartRateField.Clear();
                    HeartRateField.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "observationCellNames_heartRate")]
            [CacheLookup]
            private IWebElement HeartRateField { get; set; }
            #endregion

            #region Resp Rate
            public string RespRate
            {
                get
                {
                    return RespRateField.GetAttribute("value");
                }
                set
                {
                    RespRateField.Clear();
                    RespRateField.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "observationCellNames_respRate")]
            [CacheLookup]
            private IWebElement RespRateField { get; set; }
            #endregion

            #region O2 Sat
            public string O2Sat
            {
                get
                {
                    return O2SatField.GetAttribute("value");
                }
                set
                {
                    O2SatField.Clear();
                    O2SatField.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "observationCellNames_o2Sat")]
            [CacheLookup]
            private IWebElement O2SatField { get; set; }
            #endregion

            #region Pain
            public string Pain
            {
                get
                {
                    return PainField.GetAttribute("value");
                }
                set
                {
                    PainField.Clear();
                    PainField.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "observationCellNames_pain")]
            [CacheLookup]
            private IWebElement PainField { get; set; }
            #endregion

            #region BMI
            public string BMI
            {
                get
                {
                    return BMIField.GetAttribute("value");
                }
                set
                {
                    BMIField.Clear();
                    BMIField.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "observationCellNames_bmi")]
            [CacheLookup]
            private IWebElement BMIField { get; set; }
            #endregion

            #region BSA
            public string BSA
            {
                get
                {
                    return BSAField.GetAttribute("value");
                }
                set
                {
                    BSAField.Clear();
                    BSAField.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "observationCellNames_bsa")]
            [CacheLookup]
            private IWebElement BSAField { get; set; }
            #endregion

            #region Maximum Observations to Return
            public int MaximumObservationsToReturn
            {
                get
                {
                    return int.Parse(MaximumObservationsToReturnField.GetAttribute("value"));
                }
                set
                {
                    MaximumObservationsToReturnField.Clear();
                    MaximumObservationsToReturnField.SendKeys(value.ToString());
                }
            }
            [FindsBy(How = How.Id, Using = "maxObservationValuesToReturnTextbox")]
            [CacheLookup]
            private IWebElement MaximumObservationsToReturnField { get; set; }
            #endregion
        }
        #endregion

        #region *** Notify Service Error Settings section ***
        public NotifyServiceErrorSettings NotifyServiceError
        {
            get
            {
                //initialize if null
                if (_notifyServiceErrorSettings == null)
                    _notifyServiceErrorSettings = new NotifyServiceErrorSettings(Driver);
                return _notifyServiceErrorSettings;
            }
        }

        public class NotifyServiceErrorSettings
        {
            public NotifyServiceErrorSettings(IWebDriver driver)
            {
                PageFactory.InitElements(driver, this);
            }

            #region Emails
            public string Emails
            {
                get
                {
                    return EmailsField.GetAttribute("value");
                }
                set
                {
                    EmailsField.Clear();
                    EmailsField.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "serviceEmailTextBox")]
            [CacheLookup]
            private IWebElement EmailsField { get; set; }
            #endregion

            #region Service Calls
            public string ServiceCalls
            {
                get
                {
                    return ServiceCallsField.GetAttribute("value");
                }
                set
                {
                    ServiceCallsField.Clear();
                    ServiceCallsField.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "serviceCallsTextBox")]
            [CacheLookup]
            private IWebElement ServiceCallsField { get; set; }
            #endregion
        }
        #endregion

        #region *** Order Entry - Orderset Settings section ***
        public OrderEntryOrdersetSettings OrderEntryOrderset
        {
            get
            {
                //initialize if null
                if (_orderEntryOrdersetSettings == null)
                    _orderEntryOrdersetSettings = new OrderEntryOrdersetSettings(Driver);
                return _orderEntryOrdersetSettings;
            }
        }

        public class OrderEntryOrdersetSettings
        {
            public OrderEntryOrdersetSettings(IWebDriver driver)
            {
                PageFactory.InitElements(driver, this);
            }

            #region Emails
            public string Emails
            {
                get
                {
                    return EmailsField.GetAttribute("value");
                }
                set
                {
                    EmailsField.Clear();
                    EmailsField.SendKeys(value);
                }
            }
            [FindsBy(How = How.Id, Using = "serviceEmailTextBox")]
            [CacheLookup]
            private IWebElement EmailsField { get; set; }
            #endregion

            #region Display Start Field on Order Set Form
            public bool DisplayStartFieldOnOrderSetForm
            {
                get
                {
                    return DisplayStartFieldRadioButtonOn.Selected;
                }

                set
                {
                    if (value)
                        DisplayStartFieldRadioButtonOn.Click();
                    else
                        DisplayStartFieldRadioButtonOff.Click();
                }
            }

            [FindsBy(How = How.Id, Using = "displayStartFieldRadioButtonOn")]
            [CacheLookup]
            private IWebElement DisplayStartFieldRadioButtonOn { get; set; }

            [FindsBy(How = How.Id, Using = "displayStartFieldRadioButtonOff")]
            [CacheLookup]
            private IWebElement DisplayStartFieldRadioButtonOff { get; set; }
            #endregion

            #region Display When Field on Order Set Form
            public bool DisplayWhenFieldOnOrderSetForm
            {
                get
                {
                    return DisplayWhenFieldRadioButtonOn.Selected;
                }

                set
                {
                    if (value)
                        DisplayWhenFieldRadioButtonOn.Click();
                    else
                        DisplayWhenFieldRadioButtonOff.Click();
                }
            }

            [FindsBy(How = How.Id, Using = "displayWhenFieldRadioButtonOn")]
            [CacheLookup]
            private IWebElement DisplayWhenFieldRadioButtonOn { get; set; }

            [FindsBy(How = How.Id, Using = "displayWhenFieldRadioButtonOff")]
            [CacheLookup]
            private IWebElement DisplayWhenFieldRadioButtonOff { get; set; }
            #endregion

            #region Search Sets
            public string SearchSets
            {
                get
                {
                    return SearchSetsField.GetAttribute("value");
                }
                set
                {
                    //enter text
                    SearchSetsField.Clear();
                    SearchSetsField.SendKeys(value);
                    //press add button
                    AddButton.Click();
                }
            }

            [FindsBy(How = How.Id, Using = "searchSetsTextBox")]
            [CacheLookup]
            private IWebElement SearchSetsField { get; set; }

            [FindsBy(How = How.LinkText, Using = "Add")]
            [CacheLookup]
            private IWebElement AddButton { get; set; }
            #endregion

            #region Added Sets
            public string AddedSets
            {
                get
                {
                    return AddedSetsField.GetAttribute("value");
                }
                set
                { 
                    AddedSetsField.Clear();
                    AddedSetsField.SendKeys(value);
                }
            }

            [FindsBy(How = How.Id, Using = "addedSetsTextBox")]
            [CacheLookup]
            private IWebElement AddedSetsField { get; set; }
            #endregion

            #region Priorities
            public string Priorities
            {
                get
                {
                    return PrioritiesField.GetAttribute("value");
                }
                set
                {
                    PrioritiesField.Clear();
                    PrioritiesField.SendKeys(value);
                }
            }

            [FindsBy(How = How.Id, Using = "addedPrioritiesTextBox")]
            [CacheLookup]
            private IWebElement PrioritiesField { get; set; }
            #endregion
        }
        #endregion
    }
}
