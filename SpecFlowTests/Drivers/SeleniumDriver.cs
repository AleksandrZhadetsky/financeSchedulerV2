using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowTests.Views;

namespace SpecFlowTests.Drivers
{
    public class SeleniumDriver : IDisposable
    {
        private ChromeDriver _driver;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void WaitForHomePageLoad()
        {
            var homeView = new HomeView(Driver());

            WaitHelper.WaitTill(() => homeView.GetHomeUrl() == GetCurrentUrl(), 30000);

            homeView.WaitForPageLoad();
        }

        public string GetCurrentUrl()
        {
            return DriverUtilities.GetCurrentUrl(Driver());
        }

        private IWebDriver Driver()
        {
            if (_driver != null)
            {
                return _driver;
            }

            try
            {
                _driver = SeleniumDriverHelper.CreateChromeDriver();

                return _driver;
            }
            catch (WebDriverException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
