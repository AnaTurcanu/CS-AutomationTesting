using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;

namespace Laboratory_5.StepBindings
{
    [Binding]
    public class ContactFormFeatureSteps
    {
        private static ChromeDriver chromeDriver;

        public ContactFormFeatureSteps() => chromeDriver = new ChromeDriver();

        IWebElement contactForm;

        [Given(@"the main page is shown")]
        public void GivenTheMainPageIsShown()
        {
            chromeDriver.Url = "https://adoring-pasteur-3ae17d.netlify.app/index.html";
        }

        [Given(@"option Contact from menu bar is clicked")]
        public void GivenOptionContactFromMenuBarIsClicked()
        {
            IWebElement contactButton = chromeDriver.FindElement(By.XPath("//div[@class='collapse navbar-collapse menu--shylock']//ul[1]//li[5]//a"));
            contactButton.Click();
        }

        [Given(@"text field under Name is filled with some text")]
        public void GivenTextFieldUnderNameIsFilledWithSomeText()
        {
            contactForm = chromeDriver.FindElement(By.XPath("//div[@class='col-md-6 contact-form']"));
            IWebElement nameField = contactForm.FindElement(By.Name("Name"));
            nameField.Click();
            nameField.SendKeys("Ana");
        }

        [Given(@"text field under Email is filled with valid email address")]
        public void GivenTextFieldUnderEmailIsFilledWithValidEmailAddress()
        {
            IWebElement emailField = contactForm.FindElement(By.Name("Email"));
            emailField.Click();
            emailField.SendKeys("ana98turcanu@gmail.com");
        }

        [Given(@"text field under Subject is filled with subject")]
        public void GivenTextFieldUnderSubjectIsFilledWithSubject()
        {
            IWebElement subjectField = contactForm.FindElement(By.Name("Subject"));
            subjectField.Click();
            subjectField.SendKeys("Lorem ipsum");
        }

        [Given(@"text field under Message is filled with message")]
        public void GivenTextFieldUnderMessageIsFilledWithMessage()
        {
            IWebElement messageField = contactForm.FindElement(By.Name("Message"));
            messageField.Click();
            messageField.SendKeys(" Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");
        }

        [When(@"button Send is clicked")]
        public void WhenButtonSendIsClicked()
        {
            IWebElement sendButton = contactForm.FindElement(By.CssSelector("input[value='SEND']"));
            sendButton.Click();
        }

        [Then(@"I am redirected to confirmation of delivery page")]
        public void ThenIAmRedirectedToConfirmationOfDeliveryPage()
        {
            IWebElement pageNotFound = chromeDriver.FindElement(By.CssSelector("div[class='header'] h1"));
            string returnMessage = pageNotFound.GetProperty("innerText");
            Console.WriteLine("\n-------------------------------------------------\n");
            Console.WriteLine("\nLast step result:");
            Console.WriteLine("\n"+returnMessage.ToUpper()+"\n");
            Console.WriteLine("\n-------------------------------------------------\n");


        }
    }
}