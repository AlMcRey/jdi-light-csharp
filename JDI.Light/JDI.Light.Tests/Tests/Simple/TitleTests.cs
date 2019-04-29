﻿using NUnit.Framework;

namespace JDI.Light.Tests.Tests.Simple
{
    [TestFixture]
    public class TitleTests : TestBase
    {
        private readonly string _text = "JDI TESTING PLATFORM";

        [SetUp]
        public void SetUp()
        {
            TestSite.Html5Page.Open();
            TestSite.Html5Page.CheckOpened();
        }

        [Test]
        public void GetTextTest()
        {
            Assert.AreEqual(TestSite.Html5Page.JdiTitle.GetText(), _text);
        }

        [Test]
        public void GetValueTest()
        {
            Assert.AreEqual(TestSite.Html5Page.JdiTitle.GetValue(), _text);
        }

        [Test]
        public void ClickTest()
        {
            TestSite.Html5Page.JdiTitle.Click();
            Assert.AreEqual(TestSite.Html5Page.GetAlert().GetAlertText(), "JDI Title");
            TestSite.Html5Page.GetAlert().AcceptAlert();
        }
    }
}