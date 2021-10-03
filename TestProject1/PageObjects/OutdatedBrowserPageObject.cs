using OpenQA.Selenium;

namespace TestProject1.PageObjects
{
    public class OutdatedBrowserPageObject : BasePageObject
    {
        private readonly By _continueButton = By.CssSelector("button.detailsLink");

        public OutdatedBrowserPageObject(IWebDriver driver) : base(driver) { }

        public LoginPageObject ContinueButtonClick()
        {

            var btn = _driver.FindElement(_continueButton);
            btn.Click();
            return new LoginPageObject(_driver);
        }
    }
}
