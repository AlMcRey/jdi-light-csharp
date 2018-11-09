﻿using System.Collections.Generic;
using System.Linq;
using JDI.Commons;
using JDI.Core.Interfaces.Complex;
using JDI.Core.Settings;
using JDI.Web.Selenium.Base;
using JDI.Web.Selenium.Elements.Common;
using OpenQA.Selenium;

namespace JDI.Web.Selenium.Elements.Complex
{
    public class TextList : WebBaseElement, ITextList
    {
        public new List<IWebElement> WebElements => base.WebElements;
        private readonly Elements<Label> _texts;
        
        public TextList() : this(null) { }

        public TextList(By locator, List<IWebElement> webElements = null) : 
            base(locator, webElements: webElements)
        {
            _texts = new Elements<Label>(Locator);
        }

        public int Count()
        {
            return _texts.Count;
        }

        public IList<string> WaitText(string expected)
        {
            if (Timer.Wait(() => Texts.Contains(expected)))
                return Texts;
            throw JDISettings.Exception($"Wait Text '{expected}' Failed ({ToString()}");
        }

        public IList<string> Texts => _texts.Select(el => el.GetText).ToList();
        public IList<Label> TextElements => _texts;

        public string this[int index]
        {
            get
            {
                var texts = Texts;
                return index >= 0
                    ? texts[index]
                    : texts[texts.Count - index]; }
            set { /* Not applicable */ }
        }

        public string Value => Texts.Print();

        public bool Displayed
        {
            get
            {
                var elements = WebElements;
                return elements != null && elements.Any(el => el.Displayed);
            }
        }

        public bool Hidden
        {
            get
            {
                var elements = WebElements;
                return elements == null || !elements.Any() || elements.All(el => !el.Displayed);
            }
        }
        public void WaitDisplayed()
        {
            if (!Timer.Wait(() =>
            {
                var elements = WebElements;
                return elements != null && elements.Any() && elements.All(el => el.Displayed);
            }))
                throw JDISettings.Exception($"Wait displayed failed ({ToString()})");
        }

        public void WaitVanished()
        {
            if (!Timer.Wait(() =>
            {
                var elements = WebElements;
                return elements == null || !elements.Any() && elements.All(el => !el.Displayed);
            }))
                throw JDISettings.Exception($"Wait vanished failed ({ToString()})");
        }
    }
}