using SpecFlowTests.DSL;

namespace SpecFlowTests.StepDefinitions
{
    [Binding]
    public sealed class IdentitySteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private readonly DslFactory _dslFactory;
        private readonly string testUsername = "username";
        private readonly string testPassword = "password";

        [Given("the user on the Home page")]
        public void TheUserInTheHomePage()
        {
            _dslFactory.HomeDsl.WaitForHomePageLoad();
        }

        [When("the user clicks registration button, enter valid credentials and submit")]
        public void TheUserClicksTheRegistrationButtonEnterValidCredentialsAndSubmit()
        {
            _dslFactory.HomeDsl.ClickRegistrationButton();
            _dslFactory.HomeDsl.RegistrationDialogIsOpened();
            _dslFactory.HomeDsl.EnterCredentials(testUsername, testPassword);
            _dslFactory.HomeDsl.ClickSubmitButton();
        }

        [Then("the user is created and logged in the application")]
        public void TheUserIsCreatedAndLoggedInTheApplication()
        {
            _dslFactory.AccountDsl.WaitForHomePageLoad();
            _dslFactory.AccountDsl.UserInfoIsDisplayed();
        }
    }
}