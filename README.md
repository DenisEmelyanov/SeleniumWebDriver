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

            configTab.AllowCredentialsToBeSavedOnDevice = false;
            Assert.IsFalse(configTab.AllowCredentialsToBeSavedOnDevice, "AllowCredentialsToBeSavedOnDevice is not false");
            configTab.AllowCredentialsToBeSavedOnDevice = true;
            Assert.IsTrue(configTab.AllowCredentialsToBeSavedOnDevice, "AllowCredentialsToBeSavedOnDevice is not true");

            int initialTime = configTab.AppInactivityTimeout;
            configTab.AppInactivityTimeout = 10;
            Assert.AreEqual(configTab.AppInactivityTimeout, 10, "AppInactivityTimeout failed to update");
            configTab.AppInactivityTimeout = initialTime;            

            int time = configTab.TimeBetweenLogons;
            configTab.TimeBetweenLogons = 2;
            Assert.AreEqual(configTab.TimeBetweenLogons, 2, "TimeBetweenLogons failed to update");
            configTab.TimeBetweenLogons = time;

            configTab.PasscodeEnabled = false;
            Assert.IsFalse(configTab.PasscodeEnabled, "PasscodeEnabled is not false");
            configTab.PasscodeEnabled = true;
            Assert.IsTrue(configTab.PasscodeEnabled, "PasscodeEnabled is not true");

            string smSecurityRight = configTab.SunriseMobileSecurityRight;
            configTab.SunriseMobileSecurityRight = "no rights";
            Assert.AreEqual("no rights", configTab.SunriseMobileSecurityRight, "SunriseMobileSecurityRight failed to update");
            configTab.SunriseMobileSecurityRight = smSecurityRight;

            PatientPhotosOption initialSelectedOption = configTab.PatientPhotos;
            configTab.PatientPhotos = PatientPhotosOption.NoPhotos;
            Assert.AreEqual(PatientPhotosOption.NoPhotos, configTab.PatientPhotos, "NoPhotos is not selected");
            configTab.PatientPhotos = PatientPhotosOption.ViewOnly;
            Assert.AreEqual(PatientPhotosOption.ViewOnly, configTab.PatientPhotos, "ViewOnly is not selected");
            configTab.PatientPhotos = PatientPhotosOption.ViewAndTake;
            Assert.AreEqual(PatientPhotosOption.ViewAndTake, configTab.PatientPhotos, "ViewAndTake is not selected");
            configTab.PatientPhotos = initialSelectedOption;

            PatientBannerOption bannerOption = configTab.PatientBannerListSelection;
            configTab.PatientBannerListSelection = PatientBannerOption.UK;
            Assert.AreEqual(PatientBannerOption.UK, configTab.PatientBannerListSelection, "UK is not selected");
            configTab.PatientBannerListSelection = PatientBannerOption.Standard;
            Assert.AreEqual(PatientBannerOption.Standard, configTab.PatientBannerListSelection, "Standard is not selected");
            configTab.PatientBannerListSelection = bannerOption;

            configTab.SaveChanges();

            //smmc.Close();
        }
```
