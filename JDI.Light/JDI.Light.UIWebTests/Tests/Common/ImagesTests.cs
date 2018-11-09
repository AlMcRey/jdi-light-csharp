﻿using JDI.Core.Interfaces.Common;
using JDI.Core.Settings;
using JDI.Matchers.NUnit;
using JDI.UIWebTests.UIObjects;
using NUnit.Framework;

namespace JDI.UIWebTests.Tests.Common
{
    public class ImagesTests
    {
        private IImage _logoImage = TestSite.HomePage.LogoImage;
        private const string ALT = "ALT";
        private const string SRC = "https://jdi-framework.github.io/tests/images/Logo_Epam_Color.svg";

        [SetUp]
        public void SetUp()
        {
            JDISettings.Logger.Info("Navigating to Metals and Colors page.");
            TestSite.HomePage.Open();
            TestSite.HomePage.CheckTitle();
            TestSite.HomePage.IsOpened();
            JDISettings.Logger.Info("Setup method finished");
            JDISettings.Logger.Info("Start test: " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ClickTest()
        {
            TestSite.ContactFormPage.Open();
            _logoImage.Click();
            TestSite.HomePage.IsOpened();            
        }

        [Test]
        public void SetAttributeTest()
        {
            string _attributeName = "testAttr";
            string _value = "testValue";
            _logoImage.SetAttribute(_attributeName, _value);
            new Check().AreEquals(_logoImage.GetAttribute(_attributeName), _value);                
        }

        [Test]
        public void GetSourceTest()
        {
            new Check().AreEquals(_logoImage.GetSource(), SRC);            
        }

        [Test]
        public void GetTipTest()
        {
            new Check().AreEquals(_logoImage.GetAlt(), ALT);            
        }
    }
}