using JDI.Light.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static JDI.Light.Asserts.SoftAssert;

namespace JDI.Light.Tests.Tests.Common
{
    [TestFixture]
    public class SoftAsserts : TestBase
    {
        [SetUp]
        public void SetUp()
        {
            TestSite.Html5Page.Open();
            TestSite.Html5Page.CheckOpened();
            AssertStrict();
        }

        [TearDown]
        public void End()
        {
            ClearResults();
            AssertStrict();
        }

        [Test]
        public void NoErrorTest()
        {
            AssertSoft();
            TestSite.Html5Page.RedButton.Is.Enabled().Disabled().Displayed();
        }
    }
}
