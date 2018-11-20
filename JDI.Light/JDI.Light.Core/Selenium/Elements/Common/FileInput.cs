﻿using System;
using JDI.Core.Interfaces.Common;
using JDI.Core.Selenium.Base;
using OpenQA.Selenium;

namespace JDI.Core.Selenium.Elements.Common
{
    public class FileInput : TextField, IFileInput
    {
        protected new Action<UIElement, string> SetValueAction = (el, val) => ((FileInput) el).Input(val);

        public FileInput() : this(null)
        {
        }

        public FileInput(By byLocator = null, IWebElement webElement = null, UIElement element = null)
            : base(byLocator, webElement, element)
        {
        }
    }
}