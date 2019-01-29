using System;
using JDI.Light.Enums;
using OpenQA.Selenium;

namespace JDI.Light.Interfaces
{
    public interface IDriverFactory<out T>
    {
        Func<IWebElement, bool> ElementSearchCriteria { get; set; }
        IWebDriver GetLocalWebDriver(DriverType driverType = DriverType.Chrome);
    }
}