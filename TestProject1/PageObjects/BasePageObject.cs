using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.PageObjects
{
    public abstract class BasePageObject
    {
        protected IWebDriver _driver;

        public BasePageObject(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
