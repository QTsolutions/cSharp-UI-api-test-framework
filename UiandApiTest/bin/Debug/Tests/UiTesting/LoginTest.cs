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
    public class LoginTest : BasePage
    {
        [Test]
            public void InvalidLogin()
            {
                LoginPage lp = new LoginPage();
                lp.Login("test@gmail.com", "prek123");
                Assert.True(driver.Title.Contains("Amazon Sign In"));
            Report.LogToReport(AventStack.ExtentReports.Status.Pass, "Invalid Login");
        }
        }
    }
