using SpecFlowTests.Drivers;

namespace SpecFlowTests.DSL
{
    public class HomeDsl
    {
        public readonly SeleniumDriver _driver;

        public HomeDsl(SeleniumDriver driver)
        {
            _driver = driver;
        }

        public void WaitForHomePageLoad()
        {
            _driver.WaitForHomePageLoad();
        }

        // here re-use methods from SeleniumDriver
    }
}