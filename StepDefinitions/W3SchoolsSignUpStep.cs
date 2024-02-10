using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace W3SchoolsAutomation.StepDefinitions
{
    [Binding]
    public class W3SchoolsSignUpStep
    {

         IWebDriver driver;



        [Given(@"Navigate to W3Schools web page")]
        public void GivenNavigateToWSchoolsWebPage()
        {

            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://www.w3schools.com/");
            driver.Manage().Window.Maximize();
        }

        [When(@"User is on the '([^']*)' page")]
        public void WhenUserIsOnThePage(string signUp)
        {
            driver.FindElement(By.XPath("(//a[contains(text(),'" + signUp + "')])[1]")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Sign Up For Free')]")).Click();
            //Thread.Sleep(5000);
        }


        [Given(@"User enters valid '([^']*)' as Userid and '([^']*)' as Password details")]
        public void GivenUserEntersValidAsUseridAndAsPasswordDetails(string Userid, string Password)
        {
            //Thread.Sleep(1000);
            driver.FindElement(By.Id("modalusername")).SendKeys(Userid);
            driver.FindElement(By.Name("new-password")).SendKeys(Password);
            driver.FindElement(By.XPath("//button/span[contains(text(),'Sign up for free')]")).Click();

        }


        [When(@"User able to enter user FirstName'([^']*)', LastName '([^']*)' and click on Continue")]
        public void WhenUserAbleToEnterUserFirstNameLastNameAndClickOnContinue(string FirstName, string LastName)
        {
            driver.FindElement(By.Id("modal_first_name")).SendKeys(FirstName);
            driver.FindElement(By.Id("modal_last_name")).SendKeys(LastName);
            driver.FindElement(By.XPath("//button/span[contains(text(),'Continue')]")).Click();
        }


        [Then(@"User recieve the verify email in '([^']*)' as Userid")]
        public void ThenUserRecieveTheVerifyEmailInAsUserid(string Userid)
        {
            string ActualText = (driver.FindElement(By.XPath("//div[contains(text(),'ve sent an email to')]"))).Text;
            string ExpectedText = $"We've sent an email to {Userid} with instructions.";
            Assert.AreEqual(ExpectedText, ActualText);
            driver.Quit();
        }


        [Then(@"An error message '([^']*)' should be displayed, and the registration should not proceed")]
        public void ThenAnErrorMessageShouldBeDisplayedAndTheRegistrationShouldNotProceed(string ErrorMessage)
        {
            string ActualText = (driver.FindElement(By.XPath("//span[contains(text(),'"+ErrorMessage+"')]"))).Text;
            string ExpectedText = "Looks like you already have a user. Did you try logging in?";
            Assert.AreEqual(ExpectedText, ActualText);
            driver.Quit();
        }

        [When(@"Appropriate error messages '([^']*)' should be displayed, and the registration should not proceed")]
        public void WhenAppropriateErrorMessagesShouldBeDisplayedAndTheRegistrationShouldNotProceed(string ErrorMessage)
        {
            string ActualText = (driver.FindElement(By.XPath("//span[contains(text(),'"+ ErrorMessage + "')]"))).Text;
            string ExpectedText = "Please enter an email";
            Assert.AreEqual(ExpectedText, ActualText);
            driver.Quit();
        }




    }
}
