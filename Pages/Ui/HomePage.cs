using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UiandApiTest.Pages.Ui
{
    public class HomePage: BasePage
    {
        public IWebElement searchtextbox => driver.FindElement(By.Id("twotabsearchtextbox"));
        public IWebElement searchBtn => driver.FindElement(By.Id("nav-search-submit-button"));
        public IWebElement signinlink => driver.FindElement(By.Id("nav-link-accountList"));

        public HomePage()
        {
            PageFactory.InitElements(driver, this);
        }

        public void Search(string searchText)
        {
            searchtextbox.SendKeys(searchText);
            searchBtn.Click();
        }
    }
}
