﻿using System;
using JDI.Light.Enums;
using OpenQA.Selenium;

namespace JDI.Light.Elements.Composite
{
    public class WebSite
    {
        public string DriverName { set; get; }
        public IWebDriver WebDriver => Jdi.DriverFactory.GetLocalWebDriver(DriverType.Chrome);
        public string Url => WebDriver.Url;
        public string BaseUrl => new Uri(WebDriver.Url).GetLeftPart(UriPartial.Authority);
        public string Title => WebDriver.Title;
        
        public void Open()
        {
            WebDriver.Navigate().GoToUrl(Jdi.Domain);
        }

        public void OpenUrl(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public void OpenBaseUrl()
        {
            WebDriver.Navigate().GoToUrl(BaseUrl);
        }

        public void Refresh()
        {
            WebDriver.Navigate().Refresh();
        }

        public void Forward()
        {
            WebDriver.Navigate().Forward();
        }

        public void Back()
        {
            WebDriver.Navigate().Back();
        }
    }
}