# SeleniumWebDriver

Page Factory concept example.

Usage:
```c#
        [Test]
        [Android, iOS]
        [Category("UTIL")]
        [Author("Denis Emelyanov")]
        public void SMMCConfigTest()
        {
            var smmc = new SMMConsole();
            //var configTab = smmc.Login("xxx", "xxx").SelectTab(ConsoleTab.Config);
            var configTab = smmc.Login("xxx", "xxx").SelectConfigTab();

            configTab.Security.AllowCredentialsToBeSavedOnDevice = false;
            Assert.IsFalse(configTab.Security.AllowCredentialsToBeSavedOnDevice, "AllowCredentialsToBeSavedOnDevice is not false");
            configTab.Security.AllowCredentialsToBeSavedOnDevice = true;
            Assert.IsTrue(configTab.Security.AllowCredentialsToBeSavedOnDevice, "AllowCredentialsToBeSavedOnDevice is not true");

            int initialTime = configTab.Security.AppInactivityTimeout;
            configTab.Security.AppInactivityTimeout = 10;
            Assert.AreEqual(10, configTab.Security.AppInactivityTimeout, "AppInactivityTimeout failed to update");
            configTab.Security.AppInactivityTimeout = initialTime;            

            int time = configTab.Security.TimeBetweenLogons;
            configTab.Security.TimeBetweenLogons = 2;
            Assert.AreEqual(2, configTab.Security.TimeBetweenLogons, "TimeBetweenLogons failed to update");
            configTab.Security.TimeBetweenLogons = time;

            configTab.Security.PasscodeEnabled = false;
            Assert.IsFalse(configTab.Security.PasscodeEnabled, "PasscodeEnabled is not false");
            configTab.Security.PasscodeEnabled = true;
            Assert.IsTrue(configTab.Security.PasscodeEnabled, "PasscodeEnabled is not true");

            string smSecurityRight = configTab.Security.SunriseMobileSecurityRight;
            configTab.Security.SunriseMobileSecurityRight = "no rights";
            Assert.AreEqual("no rights", configTab.Security.SunriseMobileSecurityRight, "SunriseMobileSecurityRight failed to update");
            configTab.Security.SunriseMobileSecurityRight = smSecurityRight;

            PatientPhotosOption initialSelectedOption = configTab.ClientFeatures.PatientPhotos;
            configTab.ClientFeatures.PatientPhotos = PatientPhotosOption.NoPhotos;
            Assert.AreEqual(PatientPhotosOption.NoPhotos, configTab.ClientFeatures.PatientPhotos, "NoPhotos is not selected");
            configTab.ClientFeatures.PatientPhotos = PatientPhotosOption.ViewOnly;
            Assert.AreEqual(PatientPhotosOption.ViewOnly, configTab.ClientFeatures.PatientPhotos, "ViewOnly is not selected");
            configTab.ClientFeatures.PatientPhotos = PatientPhotosOption.ViewAndTake;
            Assert.AreEqual(PatientPhotosOption.ViewAndTake, configTab.ClientFeatures.PatientPhotos, "ViewAndTake is not selected");
            configTab.ClientFeatures.PatientPhotos = initialSelectedOption;

            PatientBannerOption bannerOption = configTab.International.PatientBannerListSelection;
            configTab.International.PatientBannerListSelection = PatientBannerOption.UK;
            Assert.AreEqual(PatientBannerOption.UK, configTab.International.PatientBannerListSelection, "UK is not selected");

            string nhsNumberIDType = configTab.International.NHSNumberIDType;
            configTab.International.NHSNumberIDType = "Visit : Visit Number pre A";
            Assert.AreEqual("Visit : Visit Number pre A", configTab.International.NHSNumberIDType, "Expected NHSNumberIDType is not selected");
            configTab.International.NHSNumberIDType = nhsNumberIDType;

            configTab.International.PatientBannerListSelection = PatientBannerOption.Standard;
            Assert.AreEqual(PatientBannerOption.Standard, configTab.International.PatientBannerListSelection, "Standard is not selected");
            configTab.International.PatientBannerListSelection = bannerOption;

            string vitalsTemp = configTab.VitalsView.Temp;
            configTab.VitalsView.Temp = "test temp";
            Assert.AreEqual("test temp", configTab.VitalsView.Temp, "VitalsView.Temp is not updated");
            configTab.VitalsView.Temp = vitalsTemp;

            string vitalsHeight = configTab.VitalsView.Height;
            configTab.VitalsView.Height = "test height";
            Assert.AreEqual("test height", configTab.VitalsView.Height, "VitalsView.Height is not updated");
            configTab.VitalsView.Height = vitalsHeight;

            string vitalsHeight2 = configTab.VitalsView.Height2;
            configTab.VitalsView.Height2 = "test height2";
            Assert.AreEqual("test height2", configTab.VitalsView.Height2, "VitalsView.Height2 is not updated");
            configTab.VitalsView.Height2 = vitalsHeight2;

            string emails = configTab.NotifyServiceError.Emails;
            configTab.NotifyServiceError.Emails = "test@email.net";
            Assert.AreEqual("test@email.net", configTab.NotifyServiceError.Emails, "NotifyServiceError.Emails is not updated");
            configTab.NotifyServiceError.Emails = emails;

            string initialAddedSets = configTab.OrderEntryOrderset.AddedSets;
            configTab.OrderEntryOrderset.SearchSets = "REMOVE";
            string expectedAddedSets = "REMOVE," + initialAddedSets;
            Assert.AreEqual(expectedAddedSets, configTab.OrderEntryOrderset.AddedSets, "REMOVE set is not added");
            configTab.OrderEntryOrderset.AddedSets = initialAddedSets;

            configTab.SaveChanges();

            smmc.Close();
        }
```
