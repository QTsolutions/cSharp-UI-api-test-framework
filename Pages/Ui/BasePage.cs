using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiandApiTest.Utilities.Reporter;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UiandApiTest.Pages.Ui
{
    public class BasePage
    {
   
        [ThreadStatic]
        public static IWebDriver driver;

        [SetUp]
        public void InitScript()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.amazon.in/";
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
