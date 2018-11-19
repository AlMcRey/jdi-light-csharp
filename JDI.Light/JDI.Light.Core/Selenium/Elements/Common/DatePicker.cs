﻿using JDI.Core.Interfaces.Common;
using JDI.Core.Selenium.Base;
using OpenQA.Selenium;

namespace JDI.Core.Selenium.Elements.Common
{
    public class DatePicker : TextField, IDatePicker
    {
        public DatePicker() : this(null)
        {
        }

        public DatePicker(By byLocator = null, IWebElement webElement = null, UIElement element = null)
            : base(byLocator, webElement, element)
        {
        }
    }
}