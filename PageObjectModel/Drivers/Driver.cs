using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace SauceDemo.PageObjectModel.Drivers
{
    public class Driver
    {
        public IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [TearDown]
        public void CleanUp()
        {
            /*_driver.Quit();
            _driver.Close();*/
        }
    }
}
