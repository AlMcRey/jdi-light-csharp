using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using JDI.Light.Enums;
using JDI.Light.Interfaces;
using JDI.Light.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace JDI.Light.Factories
{
    public class WebDriverFactory : IDriverFactory<IWebDriver>
    {
        private static string DriverPath { get; set; }
        
        public static bool OnlyOneElementAllowedInSearch = true;
        public static Size BrowserSize = new Size();
        public Func<IWebElement, bool> ElementSearchCriteria { get; set; } = el => el.Displayed;

        private ThreadLocal<Dictionary<string, IWebDriver>> LocalDrivers { get; set; }
        private ThreadLocal<Dictionary<string, IWebDriver>> RemoteDrivers { get; set; }

        public WebDriverFactory()
        {
            LocalDrivers = new ThreadLocal<Dictionary<string, IWebDriver>>(() => new Dictionary<string, IWebDriver>());
            RemoteDrivers = new ThreadLocal<Dictionary<string, IWebDriver>>(() => new Dictionary<string, IWebDriver>());
            DriverPath = AppDomain.CurrentDomain.BaseDirectory;
        }
        
        public static IWebDriver StartLocalWebDriver(DriverType browser, bool headless = false)
        {
            if (headless && !(browser == DriverType.Chrome || browser == DriverType.Firefox))
            {
                throw new ArgumentException($"Headless mode is not currently supported for browser '{browser}'");
            }

            switch (browser)
            {
                case DriverType.Chrome:
                    return GetLocalWebDriver(DriverOptionsFactory.GetChromeOptions(headless));
                default:
                    throw new PlatformNotSupportedException($"{browser} is not currently supported");
            }
        }

        public string RegisterLocalWebDriver(DriverType driverType)
        {
            try
            {
                if (Jdi.GetLatestDriver)
                {
                    if (!WebDriverUtils.IsLocalVersionLatestVersion(driverType, DriverPath))
                    {
                        DriverPath = WebDriverUtils.GetLatestVersion(driverType);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Jdi.DriverVersion))
                    {
                        DriverPath = WebDriverUtils.GetSpecifiedVersion(driverType, Jdi.DriverVersion);
                    }
                }

                var newName = $"{driverType}{Guid.NewGuid()}";
                //TODO Add method for adding new value entry to the dict
                LocalDrivers.Value = new Dictionary<string, IWebDriver>
                {
                    { newName, StartLocalWebDriver(driverType)}
                };

                return newName;
            }
            catch
            {
                throw new Exception($"Can't register local driver for : {driverType}");
            }
        }

        public IWebDriver GetLocalWebDriver()
        {
            try
            {
                var localDriver = GetLocalWebDriverByType(DriverType.Chrome);
                if (localDriver != null) 
                    return localDriver;
                string fullDriverName = RegisterLocalWebDriver(DriverType.Chrome);
                return GetLocalWebDriverByFullName(fullDriverName);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't get driver");
            }
        }

        public IWebDriver GetLocalWebDriver(DriverType driverType)
        {
            try
            {
                var localDriver = GetLocalWebDriverByType(driverType);
                if (localDriver != null)
                    return localDriver;
                string fullDriverName = RegisterLocalWebDriver(driverType);
                return GetLocalWebDriverByFullName(fullDriverName);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't get driver");
            }
        }

        public IWebDriver GetLocalWebDriverByType(DriverType driverType)
        {
            var firstMatchingKeys = LocalDrivers.Value.Keys.Where(x => x.StartsWith(driverType.ToString())).ToList();
            return !firstMatchingKeys.Any() ? null : LocalDrivers.Value[firstMatchingKeys[0]];
        }

        public IWebDriver GetLocalWebDriverByFullName(string fullDriverName)
        {
            return LocalDrivers.Value[fullDriverName];
        }

        public static IWebDriver StartRemoteWebDriver(DriverOptions options, Uri gridUrl)
        {
            return new RemoteWebDriver(gridUrl, options);
        }

        #region LocalDriverSpecificMethods

        public static IWebDriver GetLocalWebDriver(ChromeOptions options)
        {
            return new ChromeDriver(DriverPath, options);
        }
        #endregion

        #region RemoteDriverSpecificMethods

        public static IWebDriver GetRemoteWebDriver(DriverType browser, Uri gridUrl, PlatformType platformType = PlatformType.Windows)
        {
            switch (browser)
            {
                case DriverType.Chrome:
                    return StartRemoteWebDriver(DriverOptionsFactory.GetChromeOptions(platformType), gridUrl);
                default:
                    throw new PlatformNotSupportedException($"Requested '{browser}' is not currently supported");
            }
        }
        #endregion
    }
}