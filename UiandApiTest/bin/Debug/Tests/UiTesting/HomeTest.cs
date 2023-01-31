using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiandApiTest.Pages.Ui;
using UiandApiTest.Utilities.Reporter;

namespace UiandApiTest.Tests.UiTesting
{
    public class HomeTest: BasePage
    {
        [Test]
        public void SearchBook()
        {
            HomePage hp = new HomePage();
            hp.Search("English Book");
            Assert.IsTrue(driver.Title.Contains("English Book"));
            Report.LogToReport(AventStack.ExtentReports.Status.Pass, "Search for Books");
        }

        [Test]
        public void SearchPhone()
        {
            HomePage hp = new HomePage();
            hp.Search("iphone 14");
            Assert.IsTrue(driver.Title.Contains("iphone 14"));
            Report.LogToReport(AventStack.ExtentReports.Status.Pass, "Search for Iphones");
        }

        [Test]
        public void SearchWatch()
        {
            HomePage hp = new HomePage();
            hp.Search("Fastrack");
            Assert.IsTrue(driver.Title.Contains("Fastrack"));
            Report.LogToReport(AventStack.ExtentReports.Status.Pass, "Search for Watch");
        }
    }
}
