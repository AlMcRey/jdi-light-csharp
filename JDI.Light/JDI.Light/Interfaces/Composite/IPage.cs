﻿using JDI.Light.Enums;
using JDI.Light.Interfaces.Base;
using OpenQA.Selenium;

namespace JDI.Light.Interfaces.Composite
{
    public interface IPage : IBaseElement
    {
        CheckPageType CheckTitleType { get; set; }
        CheckPageType CheckUrlType { get; set; }

        ISite Parent { get; set; }
        string Url { get; set; }
        string Title { get; set; }
        string UrlTemplate { get; set; }

        IWebDriver WebDriver { get; }

        void CheckOpened();
        void Open();
    }
}