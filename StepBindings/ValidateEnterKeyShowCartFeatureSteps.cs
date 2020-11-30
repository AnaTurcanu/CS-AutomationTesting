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
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Laboratory_5.StepBindings
{
    [Binding]
    public class ValidateEnterKeyShowCartFeatureSteps
    {
        private static ChromeDriver chromeDriver;
        ChromeOptions options = new ChromeOptions();

        public ValidateEnterKeyShowCartFeatureSteps() => chromeDriver = new ChromeDriver();
        IWebElement inputBox;

        [Given(@"Main page is displayed")]
        public void GivenMainPageIsDisplayed()
        {
            chromeDriver.Url = "https://adoring-pasteur-3ae17d.netlify.app/index.html";
        }

        [Given(@"add-to-cart option under one of the items is clicked")]
        public void GivenAdd_To_CartOptionUnderOneOfTheItemsIsClicked()
        {
            //Thread.Sleep(5000);
            IWebElement firstItemAddButton = chromeDriver.FindElement(By.XPath("//div[@class='tab1 resp-tab-content resp-tab-content-active']//div[1]//div[1]//div[2]//div[2]//form"));
            firstItemAddButton.Click();
        }

        [Given(@"pop-up that appears is closed")]
        public void GivenPop_UpThatAppearsIsClosed()
        {
            IWebElement popupCloseButton = chromeDriver.FindElement(By.XPath("//div[@id='PPMiniCart']//form//button"));
            popupCloseButton.Click();
        }

        [Given(@"the cart icon on top of page is clicked")]
        public void GivenTheCartIconOnTopOfPageIsClicked()
        {
            IWebElement cartButton = chromeDriver.FindElement(By.XPath("//div[@class='top_nav_right']//div//form//button"));
            cartButton.Click();
        }

        [Given(@"clicked inside one of the text boxes that has quantity input")]
        public void GivenClickedInsideOneOfTheTextBoxesThatHasQuantityInput()
        {
            inputBox = chromeDriver.FindElement(By.XPath("//div[@id='PPMiniCart']//form//ul//li//div[2]//input"));
            inputBox.Click();
        }
        
        [When(@"enter key is hit")]
        public void WhenEnterKeyIsHit()
        {
            inputBox.SendKeys(Keys.Enter);
        }
        
        [Then(@"same page should be displayed")]
        public void ThenSamePageShouldBeDisplayed()
        {
            try
            {
                IWebElement pageNotFound = chromeDriver.FindElement(By.CssSelector("div[class='header'] h1"));
                string returnMessage = pageNotFound.GetProperty("innerText");
                Console.WriteLine("\n-------------------------------------------------\n");
                Console.WriteLine("\nLast step result:");
                Console.WriteLine("\n" + returnMessage.ToUpper() + "\n");
                Console.WriteLine("\nTEST FAILED\n");
                Console.WriteLine("\n-------------------------------------------------\n");
            }
            catch
            {
                Console.WriteLine("\n-------------------------------------------------\n");
                Console.WriteLine("\nLast step result:");
                Console.WriteLine("\nTEST PASSED\n");
                Console.WriteLine("\n-------------------------------------------------\n");
            }
        }
    }
}
