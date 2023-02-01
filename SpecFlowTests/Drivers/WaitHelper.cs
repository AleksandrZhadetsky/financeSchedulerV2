using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace SpecFlowTests.Drivers
{
    internal class WaitHelper
    {
        /// <summary>
        /// Waits for the condition to be true or the timeout to expire.
        /// </summary>
        /// <param name="condition">Func that checks the desired condition.</param>
        /// <param name="timeout">Timeout in ms.</param>
        /// <param name="operationName">Operation Name.</param>
        public static void WaitTill(Func<bool> condition, int timeout, string operationName = "")
        {
            var timeSpan = TimeSpan.FromMilliseconds(timeout);
            var i = 0;
            var start = DateTime.Now;
            while (DateTime.Now - start <= timeSpan)
            {
                i++;
                Thread.Sleep(100);
                try
                {
                    if (condition.Invoke())
                    {
                        return;
                    }
                }
                catch (StaleElementReferenceException)
                {
                }
            }

            string operation = string.IsNullOrWhiteSpace(operationName) ? string.Empty : $" {operationName}";
            throw new TimeoutException(
                $"Operation{operation} timed out. " +
                $"Given timeout was {timeout}ms, actual time spent was {(DateTime.Now - start).TotalMilliseconds}ms, retried {i} times." +
                $"\n{new StackTrace(skipFrames: 1, fNeedFileInfo: true)}");
        }

        /// <summary>
        /// Waits for the condition to be true or the timeout to expire.
        /// </summary>
        /// <param name="condition">Func that checks the desired condition.</param>
        /// <param name="timeout">timeout in ms.</param>
        /// <param name="operationName">Operation Name.</param>
        /// <returns><c>true</c> if successful; otherwise <c>false</c>.</returns>
        /// <remarks>Does not throw exception on timeout.</remarks>
        public static bool TryWaitTill(Func<bool> condition, int timeout = 1000, string operationName = "")
        {
            try
            {
                WaitTill(condition, timeout, operationName);
                return true;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (WebDriverException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static void WaitForPageLoad(IWebDriver driver)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));

            wait.Until(driver1 =>
                ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static bool WaitForCondition(IWebDriver webDriver, Func<bool> condition, int timeoutMilliseconds = 10000)
        {
            var webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(timeoutMilliseconds));

            try
            {
                return webDriverWait.Until(d => condition());
            }
            catch (WebDriverTimeoutException e)
            {
                // catch exception here so we can show a more useful error message in assert
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static void SetImplicitWait(IWebDriver driver, int timeout)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(timeout);
        }

        public static bool WaitTillElementDisplayed(IWebDriver webDriver, IWebElement element, int millisecondsTimeout = 10000) =>
            WaitForCondition(webDriver, () => element.Displayed, millisecondsTimeout);
    }
}
