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
//using ConsoleApp1;

namespace Laboratory_5.StepBindings
{
    //private ChromeDriver chromeDriver;
    [Binding]
    public class FlickrPostsFeatureSteps
    {
        private static ChromeDriver chromeDriver;

        public FlickrPostsFeatureSteps() => chromeDriver = new ChromeDriver();

        //IJavaScriptExecutor js = (IJavaScriptExecutor)chromeDriver;

        private static IWebElement firstImage;
        //private Program program;
        //IWebDriver driver;

        //[SetUp]
        //public void startBrowser()
        //{
        //    driver = new ChromeDriver("C:\\Users\\aniso\\source\\repos\\Laboratory 5\\packages\\Selenium.WebDriver.ChromeDriver.86.0.4240.2200\\driver\\win32");
        //    //driver = new ChromeDriver("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Chrome");

        //}

        [Given(@"the main page is displayed")]
        public void GivenTheMainPageIsDisplayed()
        {
            // IWebDriver driver = Program.driver;
            
            chromeDriver.Url = "https://adoring-pasteur-3ae17d.netlify.app/index.html";
            //ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have scrolled down to FLICKR Posts photo grid")]
        public void GivenIHaveScrolledDownToFLICKRPostsPhotoGrid()
        {
            firstImage = chromeDriver.FindElement(By.XPath("//div[@class='col-md-3 sign-gd flickr-post']//ul[1]//li[1]//a//img"));
            //js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            //ScenarioContext.Current.Pending();
        }

        [When(@"I click on the first image")]
        public void WhenIClickOnTheFirstImage()
        {
            if (firstImage != null)
                //Console.WriteLine("element found");
                firstImage.Click();
            else
                Console.WriteLine("ELEMENT NOT FOUND IN FLIKRPOSTSFEATURE");

                //ScenarioContext.Current.Pending();
        }

        [Then(@"I should be redirected to page with corresponding FLICKR post")]
        public void ThenIShouldBeRedirectedToPageWithCorrespondingFLICKRPost()
        {
            string resultPage = chromeDriver.Url;
            bool isFlickr = resultPage.Contains("flickr");
            Console.WriteLine("\n-------------------------------------------------\n");
            Console.WriteLine(resultPage);
            Console.WriteLine("\nLast step result:");
            if (isFlickr == false)
            {
                Console.WriteLine("\nFAILED");
                Console.WriteLine("\nUser redirected to:");
                Console.WriteLine("\n" + resultPage + "\n");
            }
            else
            {
                Console.WriteLine("\nPASSED\n");

            }
            Console.WriteLine("\n-------------------------------------------------\n");

        }

        //public void Dispose()
        //{
        //    if (chromeDriver != null)
        //    {
        //        chromeDriver.Dispose();
        //        chromeDriver = null;
        //    }
        //}

    }
}
