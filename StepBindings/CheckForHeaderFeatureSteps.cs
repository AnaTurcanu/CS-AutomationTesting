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

namespace Laboratory_5.StepBindings
{
    [Binding]
    public class CheckForHeaderFeatureSteps
    {
        public ChromeDriver chromeDriver;

        ChromeOptions options = new ChromeOptions();

        public CheckForHeaderFeatureSteps()
        {
            options.AddArguments("--disable-notifications");
            chromeDriver = new ChromeDriver(options);
        }

        [Given(@"the main page is open")]
        public void GivenTheMainPageIsOpen()
        {
            
            chromeDriver.Url = "https://www.reddit.com/";
            Thread.Sleep(2000);
        }
        
        [When(@"the word Computer is typed in the search engine")]
        public void WhenTheWordComputerIsTypedInTheSearchEngine()
        {
            IWebElement searchBox = chromeDriver.FindElement(By.CssSelector("input[id='header-search-bar']"));
            searchBox.Click();
            searchBox.SendKeys("Computer");
            searchBox.SendKeys(Keys.Enter);
        }
        
        [Then(@"the result page has header")]
        public void ThenTheResultPageHasHeader()
        {
            Thread.Sleep(1000);
            IWebElement pageHeader = chromeDriver.FindElement(By.CssSelector("header[data-redditstyle='true']"));
            Console.WriteLine("\n-------------------------------------------------\n");
            Console.WriteLine("\n Last step result:\n");

            if (pageHeader != null)
            {
                Console.WriteLine("HEADER FOUND.\n");
            }
            else
            {
                Console.WriteLine("\nHEADER NOT FOUND.\n");

            }
            Console.WriteLine("\n-------------------------------------------------\n");


        }
    }

}
