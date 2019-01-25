using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace JDI.Light.Factories
{
    public class DriverOptionsFactory
    {
        public static ChromeOptions GetChromeOptions(PlatformType platformType = PlatformType.Windows)
        {
            return GetChromeOptions(false, platformType);
        }

        public static ChromeOptions GetChromeOptions(bool headless = false, PlatformType platformType = PlatformType.Windows)
        {
            var options = new ChromeOptions();
            options.AddArguments("--disable-infobars", "test-type", "-no-sandbox", "--disable-extensions");
            options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
            //TODO change path to smth more accurate
            //options.AddUserProfilePreference("download.default_directory", @"");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            if (headless)
            {
                options.AddArgument("headless");
            }

            SetPlatform(options, platformType);
            return options;
        }

        public static T SetPlatform<T>(T options, PlatformType platformType) where T : DriverOptions
        {
            switch (platformType)
            {
                case PlatformType.Any:
                    return options;
                case PlatformType.Windows:
                    options.PlatformName = "WINDOWS";
                    return options;
                case PlatformType.Linux:
                    options.PlatformName = "LINUX";
                    return options;
                case PlatformType.Mac:
                    options.PlatformName = "MAC";
                    return options;
                default:
                    return options;
            }
        }
    }
}