using OpenQA.Selenium;
using System;

namespace TestProject1.PageObjects
{
    public class PersonalAccountPageObject : BasePageObject
    {
        private readonly By _loggedUserName = By.CssSelector("a.UserInfo_text__23wmc");
        private readonly By _profilePicture = By.CssSelector("svg.UserInfo_defaultAvatar__3dWDS");
        private readonly By _debtSum = By.CssSelector("div.main-page_info > div > div > div > span");

        public PersonalAccountPageObject(IWebDriver driver) : base(driver) { }

        public string GetLoggedUserName()
        {
            return _driver.FindElement(_loggedUserName).Text;
        }

        public int GetProfilePictureHeight()
        {
            return Convert.ToInt32(_driver.FindElement(_profilePicture).GetAttribute("height"));
        }

        public int GetProfilePictureWidth()
        {
            return Convert.ToInt32(_driver.FindElement(_profilePicture).GetAttribute("width"));
        }

        public int GetUserDebtSum()
        {
            string newDebt = "";
            var debt = _driver.FindElement(_debtSum).Text.Replace(" ", "");
            foreach (var chr in debt)
            {
                if (chr == '.')
                    break;
                newDebt += chr;
            }
            return Convert.ToInt32(newDebt);
        }
    }
}