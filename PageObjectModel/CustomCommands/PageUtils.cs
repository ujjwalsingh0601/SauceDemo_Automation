using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.PageObjectModel.CustomCommands
{
    public class PageUtils
    {
        public IWebDriver _driver;
        public PageUtils(IWebDriver driver)
        {
            _driver = driver;
        }
        public void ReloadPage()
        {
            _driver.Navigate().Refresh();
        }
    }
}
