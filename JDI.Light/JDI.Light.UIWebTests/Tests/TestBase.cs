﻿using JDI.Core.Settings;
using JDI.UIWebTests.Entities;
using JDI.UIWebTests.UIObjects;
using JDI.Web.Selenium.DriverFactory;
using JDI.Web.Selenium.Elements.Composite;
using JDI.Web.Settings;
using NUnit.Framework;

namespace JDI.UIWebTests.Tests
{
    [SetUpFixture]
    public class TestBase
    {
        [OneTimeSetUp]
        protected void SetUp()
        {            
            WebSettings.InitNUnitDefault();     
            var logger = JDISettings.Logger;
            logger.Info("Init test run...");
            WinProcUtils.KillAllRunWebDrivers();
            WebSite.Init(typeof(TestSite));
            TestSite.HomePage.Open();
            TestSite.LoginForm.Submit(User.DefaultUser);            
            logger.Info("Run test...");
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            // Some log outputs
            WinProcUtils.KillAllRunWebDrivers();
        }
    }
}