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
    public class ValidatePriceRangeSliderFeatureSteps
    {
        private static ChromeDriver chromeDriver;
        ChromeOptions options = new ChromeOptions();

        public ValidatePriceRangeSliderFeatureSteps() => chromeDriver = new ChromeDriver();
        IWebElement upperLimit;

       [Given(@"main page is shown")]
        public void GivenMainPageIsShown()
        {
            chromeDriver.Url = "https://adoring-pasteur-3ae17d.netlify.app/index.html";
        }

        [Given(@"Men's wear from menu bar is clicked")]
        public void GivenMenSWearFromMenuBarIsClicked()
        {

            IWebElement mensWearButton = chromeDriver.FindElement(By.XPath("//div[@class='collapse navbar-collapse menu--shylock']//ul[1]//li[3]//a"));
            mensWearButton.Click();
          
            
        }

        [Given(@"Clothing option is clicked from the pop-up")]
        public void GivenClothingOptionIsClickedFromThePop_Up()
        {
            IWebElement mensClothingButton = chromeDriver.FindElement(By.XPath("//div[@class='collapse navbar-collapse menu--shylock']//ul[1]//li[3]//ul//div[1]//div[2]//ul//li//a"));
            mensClothingButton.Click();
        }

        [Given(@"the lower limit point of the slider is dragged all the way to the left")]
        public void GivenTheLowerLimitPointOfTheSliderIsDraggedAllTheWayToTheLeft()
        {
            IWebElement lowerLimit = chromeDriver.FindElement(By.XPath("//div[@id='slider-range']//a[1]"));
            Actions action = new Actions(chromeDriver);
            action.MoveToElement(lowerLimit).Click().DragAndDropToOffset(lowerLimit, -10, 0).Build().Perform();
        }
        
        [Given(@"the upper limit point of the slider is dragged all the way to the left")]
        public void GivenTheUpperLimitPointOfTheSliderIsDraggedAllTheWayToTheLeft()
        {
            upperLimit = chromeDriver.FindElement(By.XPath("//div[@id='slider-range']//a[2]"));
            Actions action = new Actions(chromeDriver);
            action.MoveToElement(upperLimit).Click().DragAndDropToOffset(upperLimit, -483, 0).Build().Perform();
        }
        
        [When(@"the upper limit point is dragged to the right")]
        public void WhenTheUpperLimitPointIsDraggedToTheRight()
        {
            Thread.Sleep(200);
            Actions action = new Actions(chromeDriver);
            action.MoveToElement(upperLimit).Click().DragAndDropToOffset(upperLimit, 0, 0).Build().Perform();
        }
        
        [Then(@"The upper limit point should be to the roght of the lower limit point")]
        public void ThenTheUpperLimitPointShouldBeToTheRoghtOfTheLowerLimitPoint()
        {
            string upperPosition = upperLimit.GetAttribute("style");
            Console.WriteLine("\n-------------------------------------------------\n");
            Console.WriteLine("\n Last step result:\n");

            if (upperPosition != "left: 0%;")
            {
                Console.WriteLine("\n"+upperPosition+"  TEST PASSED");
            }
            else
            {
                Console.WriteLine("\n" + upperPosition + "  TEST FAILED");

            }
            Console.WriteLine("\n-------------------------------------------------\n");
        }
    }
}
