using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;

namespace SpecFlowTests.Drivers
{
    public static class DriverUtilities
    {
        public static void SetWindowSize(IWebDriver driver, int width, int height)
        {
            driver.Manage().Window.Size = new Size(width, height);
        }

        public static string GetCurrentUrl(IWebDriver driver)
        {
            return driver.Url;
        }

        //public static string GetSessionStorageItem(ChromeDriver driver, string item)
        //{
        //    return driver.WebStorage.SessionStorage.GetItem(item);
        //}

        public static void SwitchToNextTab(IWebDriver driver)
        {
            var currentTabHandle = driver.CurrentWindowHandle;

            var newTabHandle = driver.WindowHandles.First(tab => tab != currentTabHandle);

            driver.SwitchTo().Window(newTabHandle);
        }
    }
}