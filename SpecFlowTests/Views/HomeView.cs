using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowTests.Drivers;

namespace SpecFlowTests.Views
{
    /// <summary>
    /// Calculator Page Object
    /// </summary>
    public class HomeView
    {
        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public HomeView(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        //Finding elements by ID
        private IWebElement RegisterUpButton => Driver.FindElement(By.Id("registration-btn"));
        private IWebElement LogInButton => Driver.FindElement(By.Id("login-btn"));
        private IWebElement Logo => Driver.FindElement(By.Id("logo"));
        private IWebElement LogOutButton => Driver.FindElement(By.Id("logout-btn"));

        public string ApiBaseAddress => "https://localhost:4200/";

        public IWebDriver Driver { get; }

        public new void WaitForPageLoad()
        {
            WaitHelper.WaitTill(() => GetHomeUrl() == Driver.Url, 30000);
            WaitHelper.WaitForPageLoad(Driver);
        }

        public string GetHomeUrl()
        {
            return $"{ApiBaseAddress}home";
        }

        /// <summary>
        /// Helper method to wait until the expected result is available on the UI
        /// </summary>
        /// <typeparam name="T">The type of result to retrieve</typeparam>
        /// <param name="getResult">The function to poll the result from the UI</param>
        /// <param name="isResultAccepted">The function to decide if the polled result is accepted</param>
        /// <returns>An accepted result returned from the UI. If the UI does not return an accepted result within the timeout an exception is thrown.</returns>
        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            return wait.Until(driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                {
                    return default;
                }

                return result;
            });
        }
    }
}
