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
    public class ValidateSortByFeatureSteps
    {
        private static ChromeDriver chromeDriver;
        ChromeOptions options = new ChromeOptions();

        public ValidateSortByFeatureSteps() => chromeDriver = new ChromeDriver();
        IWebElement sortByDropDown;
        IWebElement items;

        [Given(@"main page is displayed")]
        public void GivenMainPageIsDisplayed()
        {
            chromeDriver.Url = "https://adoring-pasteur-3ae17d.netlify.app/index.html";
        }
        
        [Given(@"men's wear from menu bar is clicked")]
        public void GivenMenSWearFromMenuBarIsClicked()
        {
            IWebElement mensWearButton = chromeDriver.FindElement(By.XPath("//div[@class='collapse navbar-collapse menu--shylock']//ul[1]//li[3]//a"));
            mensWearButton.Click();
        }
        
        [Given(@"""(.*)"" option is clicked")]
        public void GivenOptionIsClicked(string p0)
        {
            IWebElement mensClothingButton = chromeDriver.FindElement(By.XPath("//div[@class='collapse navbar-collapse menu--shylock']//ul[1]//li[3]//ul//div[1]//div[2]//ul//li//a"));
            mensClothingButton.Click();
        }
        
        [Given(@"""(.*)"" drop down box is clicked")]
        public void GivenDropDownBoxIsClicked(string p0)
        {
            sortByDropDown = chromeDriver.FindElement(By.Id("country1"));
            sortByDropDown.Click();
        }

        [When(@"""(.*)"" option is clicked")]
        public void WhenOptionIsClicked(string p0)
        {
            IWebElement fromAToZ = sortByDropDown.FindElement(By.XPath("//option[@value='0']"));
            fromAToZ.Click();
            items = chromeDriver.FindElement(By.XPath("//div[@class='single-pro']"));
        }

        [Then(@"the list of items below is sorted by name from A to Z")]
        public void ThenTheListOfItemsBelowIsSortedByNameFromAToZ()
        {
            int result = 1;
            int c = -1;
            IWebElement previousItem = items.FindElement(By.XPath("//div[1]//div[1]//div[2]//h4//a"));
            string previousTitle = previousItem.GetProperty("innerText");
            Console.WriteLine("\n-------------------------------------------------\n");
            Console.WriteLine("\n Last step result:\n");
            for (int i = 2; i < 5; i++)
            {
                if (c == 1)
                {
                    result = 0;
                    break;
                }
                else if (c == -1 || c == 0)
                {
                    IWebElement nextItem = items.FindElement(By.XPath("//div[" + i + "]//div[1]//div[2]//h4//a"));
                    string nextTitle = nextItem.GetProperty("innerText");
                    c = string.Compare(previousTitle, nextTitle);
                    previousTitle = nextTitle;
                } 
            }
            if (result==1)
            Console.WriteLine("\n TEST PASSED");
            if(result==0)
            Console.WriteLine("\n TEST FAILED");
            Console.WriteLine("\n-------------------------------------------------\n");

        }
    }
}
