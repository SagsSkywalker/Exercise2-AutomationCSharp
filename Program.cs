using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Exercise2_AutomationCSharp
{

    class FacebookTesting
    {
        #region WebElements
        public By CreateAccountFB { get; set; }
        public By FirstName { get; set; }
        public By LastName { get; set; }
        public By Number { get; set; }
        public By Password { get; set; }
        public By MonthPick { get; set; }
        public By DayPick { get; set; }
        public By YearPick { get; set; }
        public By FemaleGenderRbtn { get; set; }
        public By FBConnectText { get; set; }
        #endregion
        public IWebDriver driver;
        public IWebElement element;
        Program program = new Program();
        //Browser = program.SetUpDriver();
        #region Interactive Methods
        public void Click(IWebElement element) {
            element.Click();
        }
        public void SendText(IWebElement element, string value) {
            element.SendKeys(value);
        }
        #endregion

        public IWebDriver SetUpDriver() {
            driver = new ChromeDriver(@"C:\Webdrivers\");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            CreateAccountFB = By.XPath("//a[@id='u_0_2']");
            FirstName = By.XPath("//input[@name='firstname']");
            LastName = By.XPath("//input[@name='lastname']");
            Number = By.XPath("//input[@name='reg_email__']");
            Password = By.XPath("//input[@name='reg_passwd__']");
            MonthPick = By.XPath("//select[@id='month']");
            DayPick = By.XPath("//select[@id='day']");
            YearPick = By.XPath("//select[@id='year']");
            FemaleGenderRbtn = By.XPath("//label[contains(text(),'Female')]");
            FBConnectText = By.XPath("//h2[contains(text(),'Connect with friends and the world around you on F')]");
            return driver;
        }

    }
    class Program
    {
        //Exercise 2
        IWebDriver driver;
        static void Main(string[] args) {
            FacebookTesting FBTesting = new FacebookTesting();
            FBTesting.SetUpDriver();
            //Go to facebook.com.
            FBTesting.driver.Url = "https://www.facebook.com";
            //Validate the Title of the page, should be : Facebook - Log In or Sign Up.
            Assert.AreEqual(FBTesting.driver.Title, "Facebook - Log In or Sign Up");
            
            //Fill all Sign Up section.
            WebDriverWait wait = new WebDriverWait(FBTesting.driver, TimeSpan.FromSeconds(10.0));
            wait.Until(ExpectedConditions.ElementToBeClickable(FBTesting.CreateAccountFB));
            FBTesting.Click(FBTesting.driver.FindElement(FBTesting.CreateAccountFB));
            wait.Until(ExpectedConditions.ElementToBeClickable(FBTesting.FirstName));
            FBTesting.SendText(FBTesting.driver.FindElement(FBTesting.FirstName), "TestName");
            wait.Until(ExpectedConditions.ElementToBeClickable(FBTesting.LastName));
            FBTesting.SendText(FBTesting.driver.FindElement(FBTesting.LastName), "TestLastName");
            wait.Until(ExpectedConditions.ElementToBeClickable(FBTesting.Number));
            FBTesting.SendText(FBTesting.driver.FindElement(FBTesting.Number), "4771234567");
            wait.Until(ExpectedConditions.ElementToBeClickable(FBTesting.Password));
            FBTesting.SendText(FBTesting.driver.FindElement(FBTesting.Password), "Password01!");
            //Choose a different Birthday not the default one.
            wait.Until(ExpectedConditions.ElementToBeClickable(FBTesting.MonthPick));
            var selectElement = new SelectElement(FBTesting.driver.FindElement(FBTesting.MonthPick));
            selectElement.SelectByText("Jan");
            wait.Until(ExpectedConditions.ElementToBeClickable(FBTesting.DayPick));
            selectElement = new SelectElement(FBTesting.driver.FindElement(FBTesting.DayPick));
            selectElement.SelectByText("1");
            wait.Until(ExpectedConditions.ElementToBeClickable(FBTesting.YearPick));
            selectElement = new SelectElement(FBTesting.driver.FindElement(FBTesting.YearPick));
            selectElement.SelectByText("1996");
            //Click on Female.
            wait.Until(ExpectedConditions.ElementToBeClickable(FBTesting.FemaleGenderRbtn));
            FBTesting.Click(FBTesting.driver.FindElement(FBTesting.FemaleGenderRbtn));

            //Validate following text is present: Connect with friends and the world around you on Facebook.
            Assert.IsNotNull(FBTesting.driver.FindElement(FBTesting.FBConnectText));
        }
    }
}
