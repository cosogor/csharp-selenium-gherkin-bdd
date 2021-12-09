using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace CSharpTestProject.StepDefinitions
{
    [Binding]
    
    public class SearchResultPanelStepDefinitions
    {
        IWebDriver driver;
        String homeURL = "https://www.google.com";
        String searchText = "Sample_text";
        //Search panel items
        String searchBox =                     "//*[@name='q']";
        String searchButton =                  "/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]";
        //Results panel items
        String searchResultPanelAll =          "//*[@id='hdtb-msb']/div[1]/div/div[1]";
        String searchResultPanelPictures =     "//*[@id='hdtb-msb']/div[1]/div/div[2]/a";
        String searchResultPanelVideos =       "//*[@id='hdtb-msb']/div[1]/div/div[3]/a";
        String searchResultPanelNews =         "//*[@id='hdtb-msb']/div[1]/div/div[4]/a";
        String searchResultPanelPurchases =    "//*[@id='hdtb-msb']/div[1]/div/div[5]/a";
        String searchResultStatus =            "//*[@id='result-stats']";
        WebDriverWait wait;
       [Given(@"I have navigated to the google search page")]
        public void GivenIHaveNavigatedToTheGoogleSearchPage()
        {
            driver = new ChromeDriver();
            driver.Url = homeURL;
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(homeURL);
            wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
            // System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine("Page title is: " + driver.Title);
            string text = driver.Title;
            Assert.AreEqual(driver.Title, "Google");
            // throw new PendingStepException();
        }

        [When(@"input the search string to the Search Box")]
        public void WhenInputTheSearchStringToTheSearchBox()
        {
            wait.Until(driver => driver.FindElement(By.XPath(searchBox)));
            driver.FindElement(By.XPath(searchBox)).SendKeys(searchText);
            driver.FindElement(By.XPath("//*[@alt='Google']")).Click();
            //           throw new PendingStepException();
        }

        [When(@"click Search Button")]
        public void WhenClickSearchButton()
        {
            driver.FindElement(By.XPath(searchButton)).Click();
            System.Console.WriteLine("Search query Sent to:" + homeURL);
            //           throw new PendingStepException();
        }

        [Then(@"Search Result Panel available")]
        public void ThenSearchResultPanelAvailable()
        {
            wait.Until(driver => driver.FindElement(By.XPath(searchResultStatus)));
            IWebElement elementSearchResultStatus = driver.FindElement(By.XPath(searchResultStatus));
            string text1 = elementSearchResultStatus.Text; //  debud
            Assert.IsNotEmpty(elementSearchResultStatus.Text);
            System.Console.WriteLine("searchResultStatus found:" + elementSearchResultStatus.Text);

            Assert.IsNotNull(wait.Until(driver => driver.FindElement(By.XPath(searchResultPanelAll))));
            IWebElement elementSearchResultPanelAll = driver.FindElement(By.XPath(searchResultPanelAll));
            string text2 = elementSearchResultPanelAll.Text; //  debud
            Assert.AreEqual(elementSearchResultPanelAll.Text, "Все");
            System.Console.WriteLine("searchResultPanelAll found:" + elementSearchResultPanelAll.Text);

            wait.Until(driver => driver.FindElement(By.XPath(searchResultPanelPictures)));
            IWebElement elementSearchResultPanelPictures = driver.FindElement(By.XPath(searchResultPanelPictures));
            string text3 = elementSearchResultPanelPictures.Text; //  debud
            Assert.AreEqual(elementSearchResultPanelPictures.Text, "Картинки");
            System.Console.WriteLine("searchResultPanelPictures found:" + elementSearchResultPanelPictures.Text);

            wait.Until(driver => driver.FindElement(By.XPath(searchResultPanelNews)));
            IWebElement elementSearchResultPanelNews = driver.FindElement(By.XPath(searchResultPanelNews));
            string text4 = elementSearchResultPanelNews.Text; //  debud
            Assert.AreEqual(elementSearchResultPanelNews.Text, "Новости");
            System.Console.WriteLine("searchResultPanelNews found:" + elementSearchResultPanelNews.Text);

            wait.Until(driver => driver.FindElement(By.XPath(searchResultPanelPurchases)));
            IWebElement elementSearchResultPanelPurchases = driver.FindElement(By.XPath(searchResultPanelPurchases));
            string text5 = elementSearchResultPanelPurchases.Text; //  debud
            Assert.AreEqual(elementSearchResultPanelPurchases.Text, "Покупки");
            System.Console.WriteLine("searchResultPanelPurchases found:" + elementSearchResultPanelPictures.Text);

            wait.Until(driver => driver.FindElement(By.XPath(searchResultPanelPurchases)));
            IWebElement elementsearchResultPanelVideos = driver.FindElement(By.XPath(searchResultPanelVideos));
            string text6 = elementsearchResultPanelVideos.Text; //  debud
            Assert.AreEqual(elementsearchResultPanelVideos.Text, "Видео");
            System.Console.WriteLine("searchResultPanelPurchases found:" + elementsearchResultPanelVideos.Text);

            // throw new PendingStepException();
        }

        [Then(@"close the browser instance")]
        public void ThenCloseTheBrowserInstance()
        {
            driver.Close();
            // throw new PendingStepException();
        }
    }
}
