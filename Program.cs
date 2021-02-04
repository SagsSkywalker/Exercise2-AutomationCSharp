using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Exercise2_AutomationCSharp
{
    class Program
    {
        //Exercise 2
        IWebDriver driver;
        public IWebDriver SetUpDriver() {
            driver = new ChromeDriver(@"C:\Webdrivers\");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }
        #region Interactive Methods
        #region WebElements
        By CreateAccountFB = By.XPath("//a[@id='u_0_2']");
        By FirstName = By.XPath("//input[@name='firstname']");
        By LastName = By.XPath("//input[@name='lastname']");
        By Number = By.XPath("//input[@name='reg_email__']");
        By Password = By.XPath("//input[@name='reg_passwd__']");
        By MonthPick = By.XPath("//select[@id='month']");
        By DayPick = By.XPath("//select[@id='day']");
        By YearPick = By.XPath("//select[@id='year']");
        By FemaleGenderRbtn = By.XPath("//label[contains(text(),'Female')]");
        #endregion
        public void Click(IWebElement element) {
            element.Click();
        }
        public void SendText(IWebElement element, string value) {
            element.SendKeys(value);
        }
        #endregion
        static void Main(string[] args) {
            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUpDriver();
            //Go to facebook.com.
            Browser.Url = "https://www.facebook.com";
            //Validate the Title of the page, should be : Facebook - Log In or Sign Up.
            Assert.AreEqual(Browser.Title, "Facebook - Log In or Sign Up");
            //Fill all Sign Up section.
            program.Click(Browser.FindElement(program.CreateAccountFB));
            program.SendText(Browser.FindElement(program.FirstName), "TestName");
            program.SendText(Browser.FindElement(program.LastName), "TestLastName");
            program.SendText(Browser.FindElement(program.Number), "4771234567");
            program.SendText(Browser.FindElement(program.Password), "Password01!");
            //Choose a different Birthday not the default one.
            var selectElement = new SelectElement(Browser.FindElement(program.MonthPick));
            selectElement.SelectByText("Jan");
            selectElement = new SelectElement(Browser.FindElement(program.DayPick));
            selectElement.SelectByText("1");
            selectElement = new SelectElement(Browser.FindElement(program.YearPick));
            selectElement.SelectByText("1996");
            //Click on Female.
            program.Click(Browser.FindElement(program.FemaleGenderRbtn));
        }
    }
}
