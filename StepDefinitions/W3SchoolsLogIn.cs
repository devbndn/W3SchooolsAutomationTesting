using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace W3SchoolsAutomation.StepDefinitions
{
    [Binding]
    public class W3SchoolsLogIn
    {
        IWebDriver driver;

        [Given(@"Navigate to W3Schools web page for LonIn")]
        public void GivenNavigateToWSchoolsWebPageForLonIn()
        {
           
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://www.w3schools.com/");
            driver.Manage().Window.Maximize();

        }


        [Given(@"User enters valid '([^']*)' as Userid and '([^']*)' as Password detail in LogIn Page")]
        public void GivenUserEntersValidAsUseridAndAsPasswordDetailsInLogInPage(string Userid, string Password)
        {
            driver.FindElement(By.XPath("//*[@id='modalusername']")).SendKeys(Userid);
            driver.FindElement(By.XPath("//*[@id='current-password']")).SendKeys(Password);
        }

        [When(@"User should be successfully logged in")]
        public void WhenUserShouldBeSuccessfullyLoggedIn()
        {
            driver.FindElement(By.XPath("(//button/span[contains(text(),'Log in')])[1]")).Click();
        }

        [Then(@"An error message '([^']*)' should be displayed, and the user should not be logged in")]
        public void WhenAnErrorMessageShouldBeDisplayedAndTheUserShouldNotBeLoggedIn(string ErrorMessage)
        {
            string ActualText = (driver.FindElement(By.XPath("//div[contains(text(),'"+ ErrorMessage + "')]"))).Text;
            string ExpectedText = "A user with this email does not exist";
            Assert.AreEqual(ExpectedText, ActualText);
        }

        [When(@"User Navigate to '([^']*)' page")]
        public void WhenUserNavigateToPage(string Login)
        {
            driver.FindElement(By.XPath("(//a[contains(text(),'" + Login + "')])[1]")).Click();
            //Thread.Sleep(5000);
        }
        [Then(@"User close webpage")]
        public void ThenUserCloseWebpage()
        {
            driver.Quit();
        }


    }
}
