using NUnit.Framework;

namespace JDI.Light.Tests.Tests.Base
{
    [TestFixture]
    public class UIListTests : TestBase
    {
        [Test]
        public void UIListCreationTest()
        {
            var l = TestSite.HomePage.BenefitsList;
            var e = l.WebElements;
            var ui = l.List;
        }
    }
}