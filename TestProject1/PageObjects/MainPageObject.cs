using OpenQA.Selenium;

namespace TestProject1.PageObjects
{
    public class MainPageObject : BasePageObject
    {
        private readonly By _personalAccountButton = By.CssSelector("a.main-menu__enter > span.text-icon");

        public MainPageObject(IWebDriver driver) : base(driver) { }

        public OutdatedBrowserPageObject PersonalAccountButtonClick()
        {
            _driver.FindElement(_personalAccountButton).Click();
            return new OutdatedBrowserPageObject(_driver);
        }

    }
}
