﻿using JDI.Light.Tests.UIObjects.Pages;
using NUnit.Framework;

namespace JDI.Light.Tests.UITests.Composite
{
    [TestFixture]
    public class WebSiteTests : TestBase
    {
        [Test]
        public void OpenPageTest()
        {
            var page = TestSite.OpenPage<HomePage>("/index.html", "Home Page");
            page.CheckOpened();
        }
    }
}