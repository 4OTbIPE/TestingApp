using OpenQA.Selenium;

namespace TestProject1.PageObjects
{
    public class LoginPageObject : BasePageObject
    {
        private readonly By _personalAccountDemoModeButton = By.CssSelector("div.AuthorizationPage_demoButton__3ZPsz > a");
        
        public LoginPageObject(IWebDriver driver) : base(driver) { }

        public PersonalAccountPageObject DemoModeButtonClick()
        {
            _driver.FindElement(_personalAccountDemoModeButton).Click();
            return new PersonalAccountPageObject(_driver);
        }
    }
}
