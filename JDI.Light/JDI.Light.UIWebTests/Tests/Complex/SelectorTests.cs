﻿using System.Collections.Generic;
using JDI.Core.Settings;
using JDI.UIWebTests.UIObjects;
using NUnit.Framework;

namespace JDI.UIWebTests.Tests.Complex
{
    // TODO: Selector tests are not compleated
    [Ignore("Exception in CascadeInit due to oddNumberSelectors")]
    public class SelectorTests
    {
        private static readonly IList<string> OddOptions = new List<string> { "1", "3", "5", "7" };
        //private ISelector<Odds> OddNumbersSelector => MetalsColorsPage.SummaryBlock.OddNumbersSelector;

        [SetUp]
        public void SetUp()
        {
            JDISettings.Logger.Info("Navigating to Metals and Colors page.");
            TestSite.MetalsColorsPage.Open();
            TestSite.MetalsColorsPage.CheckTitle();
            TestSite.MetalsColorsPage.IsOpened();
            JDISettings.Logger.Info("Setup method finished");
            JDISettings.Logger.Info("Start test: " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void SelectStringTest()
        {
            //OddNumbersSelector.Select("7");
            //CheckAction("Summary (Odd): value changed to 7");
        }
    }
}