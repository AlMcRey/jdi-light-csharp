﻿using System;
using NUnit.Framework;

namespace JDI.Light.Tests.Tests.Simple
{
    [TestFixture]
    public class ColorPickerTests : TestBase
    {
        private readonly string _color = "#ffd7a6";

        [SetUp]
        public void SetUp()
        {
            TestSite.Html5Page.Open();
            TestSite.Html5Page.CheckOpened();
        }

        [Test]
        public void GetLabelTextTest()
        {
            // todo add test after HasLabel interface implementation
        }

        [Test]
        public void GetColorTest()
        {
            Assert.AreEqual(TestSite.Html5Page.DisabledPicker.Color(), _color);
        }

        [Test]
        public void SetColorTest()
        {
            TestSite.Html5Page.ColorPicker.SetColor("#432376");
            Assert.AreEqual(TestSite.Html5Page.ColorPicker.Color(), "#432376");
            try
            {
                TestSite.Html5Page.DisabledPicker.SetColor("#432376");
            }
            catch (Exception ignore)
            {
            }
            Assert.AreEqual(TestSite.Html5Page.DisabledPicker.Color(), _color);
        }
    }
}