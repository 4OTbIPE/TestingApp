using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using TestProject1.PageObjects;

namespace TestProject1
{
    public class Tests
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new InternetExplorerDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://nalog.ru");
        }

        [Test]
        public void NavigateToMainPage_Test()
        {
            _driver.Navigate().GoToUrl("http://nalog.ru");
            Assert.AreEqual(_driver.Url, "https://www.nalog.gov.ru/rn02/");
        }


        //���� �� ����������, ��� ���������� ���� � ����������� �� ���������� ��������
        //������� ��������� ����� ������ � ������� ����� ���� � ��������������� ���������, ���� ��� ��������� ������
        [Test]
        public void PersonalAccountLoginPage_Test()
        {
            var main = new MainPageObject(_driver);
            main
                .PersonalAccountButtonClick();
            Assert.AreEqual(_driver.Url, "https://lkfl2.nalog.ru/lkfl/login", "Loaded page is not equal to Personal Account login page!");
        }

        [Test]
        public void PersonalAccountLoginPageInOutdatedBrowser_Test()
        {
            var main = new MainPageObject(_driver);
            main
                .PersonalAccountButtonClick()
                .ContinueButtonClick();
            Assert.AreEqual(_driver.Url, "https://lkfl2.nalog.ru/lkfl/login", "Loaded page is not equal to Personal Account login page!");
        }

        [Test]
        public void LoggedPeronalAccountInOutdatedBrowser_Test()
        {
            var main = new MainPageObject(_driver);
            var demoMode = main
                .PersonalAccountButtonClick()
                .ContinueButtonClick()
                .DemoModeButtonClick();
            Assert.AreEqual("https://lkfl2.nalog.ru/lkfl-demo", _driver.Url, "Loaded page is not equal to Personal Account login page!");
            Assert.AreEqual("������ ���� ��������", demoMode.GetLoggedUserName(), "Loaded demo personal account does not belong to Ivanov Ivan Ivanovich");
        }


        //���� ���� �� �����������, ��� ������ �������� 32�32, � ���� � ������� ��������� �� 31�31
        //������� ��� ��� � ��������))
        [Test]
        public void UserProfilePictureInOutdatedBrowser_Test()
        {
            var main = new MainPageObject(_driver);
            var demoMode = main
                .PersonalAccountButtonClick()
                .ContinueButtonClick()
                .DemoModeButtonClick();
            Assert.AreEqual("https://lkfl2.nalog.ru/lkfl-demo", _driver.Url, "Loaded page is not equal to Personal Account login page!");
            Assert.AreEqual(31, demoMode.GetProfilePictureWidth(), "Wrong picture width!");
            Assert.AreEqual(31, demoMode.GetProfilePictureHeight(), "Wrong picture height!");
        }

        [Test]
        public void UserDebtInOutdatedBrowser_Test()
        {
            var main = new MainPageObject(_driver);
            var demoMode = main
                .PersonalAccountButtonClick()
                .ContinueButtonClick()
                .DemoModeButtonClick();
            Assert.AreEqual("https://lkfl2.nalog.ru/lkfl-demo", _driver.Url, "Loaded page is not equal to Personal Account login page!");
            Assert.LessOrEqual(demoMode.GetUserDebtSum(), 200000, "Wrong user debt!");
        }

        [TearDown]
        public void Exit()
        {
            _driver.Quit();
        }

        [OneTimeTearDown]
        public void ExitOneTime()
        {
            _driver.Dispose();
        }
    }
}