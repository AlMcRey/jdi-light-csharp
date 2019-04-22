﻿using JDI.Light.Tests.Enums;
using NUnit.Framework;

namespace JDI.Light.Tests.Tests.Common
{
    [TestFixture]
    public class ComboBoxTests : TestBase
    {
        [SetUp]
        public void SetUp()
        {
            TestSite.Html5Page.Open();
            TestSite.Html5Page.CheckOpened();
            TestSite.Html5Page.IceCreamComboBox.Select("Coconut");
        }

        [Test]
        public void GetValueTest()
        {
            Assert.AreEqual(TestSite.Html5Page.IceCreamComboBox.Selected(), "Coconut");
        }

        [Test]
        public void SelectTest()
        {
            TestSite.Html5Page.IceCream.Select("Chocolate");
            Assert.AreEqual(TestSite.Html5Page.IceCreamComboBox.Selected(), "Chocolate");
        }

        [Test]
        public void SelectEnumTest()
        {
            TestSite.Html5Page.IceCream.Select(IceCream.Strawberry);
            Assert.AreEqual(TestSite.Html5Page.IceCreamComboBox.Selected(), "Strawberry");
        }

        [Test]
        public void SelectNumTest()
        {
            TestSite.Html5Page.IceCream.Select(5);
            Assert.AreEqual(TestSite.Html5Page.IceCreamComboBox.Selected(), "Vanilla");
        }
    }
}