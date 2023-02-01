using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowTests.Drivers
{
    /// <summary>
    /// Selenium driver constants.
    /// </summary>
    public static class SeleniumDriverHelper
    {
        private const string ChromeBinaryLocationEnvironmentVariableName = "CHROME_BINARY_LOCATION";

        /// <summary>
        /// Creates and sets up a new instanse of ChromeDriver.
        /// </summary>
        /// <returns>A new instanse of ChromeDriver.</returns>
        /// <remark>Avoid setting the driver implicit wait here. It makes the tests run too slowly.</remark>
        public static ChromeDriver CreateChromeDriver()
        {
            var chromeOptions = new ChromeOptions();
            SetChromeBinaryLocation(chromeOptions);
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            chromeOptions.AddArguments("--headless", "--disable-gpu", "--window-size=1920,1080");

            // The 'UnhandledPromptBehavior' option was set to stabilize some integration tests.
            // It was done due to random OpenQA.Selenium.UnhandledAlertException appearances.
            // It may be removed if someone finds a better approach.
            chromeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
            var driver = new ChromeDriver(chromeOptions);

            return driver;
        }

        private static void SetChromeBinaryLocation(ChromeOptions chromeOptions)
        {
            var chromeBinaryLocation = Environment.GetEnvironmentVariable(
                ChromeBinaryLocationEnvironmentVariableName, EnvironmentVariableTarget.Machine);

            if (!string.IsNullOrWhiteSpace(chromeBinaryLocation))
            {
                chromeOptions.BinaryLocation = chromeBinaryLocation;
            }
        }
    }
}