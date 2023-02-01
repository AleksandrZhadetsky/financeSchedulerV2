using SpecFlowTests.Drivers;

namespace SpecFlowTests.DSL
{
    public sealed class DslFactory : IDisposable
    {
        private readonly SeleniumDriver seleniumDriver;

        public HomeDsl HomeDsl { get; set; }
        public AccountDsl AccountDsl { get; set; }

        public DslFactory()
        {
            seleniumDriver = new SeleniumDriver();
            HomeDsl = new HomeDsl(seleniumDriver);
            AccountDsl = new AccountDsl(seleniumDriver);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}