using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiandApiTest.Pages.Ui
{
    public class LoginPage: BasePage
    {
        public IWebElement emailtxt => driver.FindElement(By.Id("ap_email"));
        public IWebElement continuebtn => driver.FindElement(By.Id("continue"));
        public IWebElement passwordtxt => driver.FindElement(By.Id("ap_password"));
        public IWebElement signinbtn => driver.FindElement(By.Id("signInSubmit"));

        public LoginPage()
        {
            PageFactory.InitElements(driver, this);
        }

        public void Login(string user, string password)
        {
            HomePage hp = new HomePage();
            hp.signinlink.Click();
            emailtxt.SendKeys(user);
            continuebtn.Click();
            passwordtxt.SendKeys(password);
            signinbtn.Click();
        }
    }
}
