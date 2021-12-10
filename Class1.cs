using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace CSharpTestProject
{

    [TestFixture]
    public class Chrome_Sample_test
    {
        private IWebDriver driver;
        private string homeURL;
        private string searchBox;
        private string searchText;
        private string searchButton;
        private string searchResultPanelAll;
        private string searchResultPanelPictures;
        private string searchResultPanelVideos;
        private string searchResultPanelNews;
        private string searchResultPanelPurchases;
        private string searchResultStatus;
        private string googleBanner;

        [SetUp]
        public void SetupTest()
        {
            homeURL = "https://www.google.com";
            driver = new ChromeDriver();
            //Search panel items
            searchText =                    "Sample_text";
            searchBox =                     "//*[@name='q']";
            searchButton =                  "/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]";
            //Results panel items
            searchResultPanelAll =          "//*[@id='hdtb-msb']/div[1]/div/div[1]";
            searchResultPanelPictures =     "//*[@id='hdtb-msb']/div[1]/div/div[2]/a"; 
            searchResultPanelVideos =       "//*[@id='hdtb-msb']/div[1]/div/div[3]/a";
            searchResultPanelNews =         "//*[@id='hdtb-msb']/div[1]/div/div[4]/a";
           // searchResultPanelPurchases =    "//*[@id='hdtb-msb']/div[1]/div/div[5]/a"; // google убрал эту кнопку
            searchResultStatus =            "//*[@id='result-stats']";
            googleBanner =                  "//*[@alt='Google']";
        }


        [Test(Description = "Check search for count of search string")]
        public void Login_is_on_home_page()
        {
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
            System.Console.WriteLine("Page title is: " + driver.Title);

            wait.Until(driver => driver.FindElement(By.XPath(searchBox)));
            driver.FindElement(By.XPath(searchBox)).SendKeys(searchText);
            driver.FindElement(By.XPath(googleBanner)).Click();
            driver.FindElement(By.XPath(searchButton)).Click();
            System.Console.WriteLine("Search query Sent to:" + homeURL);

            wait.Until(driver => driver.FindElement(By.XPath(searchResultStatus)));
            IWebElement elementSearchResultStatus = driver.FindElement(By.XPath(searchResultStatus));
            string text1 = elementSearchResultStatus.Text; //  debud
            Assert.IsNotEmpty(elementSearchResultStatus.Text);
            System.Console.WriteLine("searchResultStatus found:" + elementSearchResultStatus.Text);

            Assert.IsNotNull(wait.Until(driver => driver.FindElement(By.XPath(searchResultPanelAll))));
            IWebElement elementSearchResultPanelAll = driver.FindElement(By.XPath(searchResultPanelAll));
            string text2 = elementSearchResultPanelAll.Text; //  debud
            Assert.AreEqual(elementSearchResultPanelAll.Text, "All");
            System.Console.WriteLine("searchResultPanelAll found:" + elementSearchResultPanelAll.Text);

            wait.Until(driver => driver.FindElement(By.XPath(searchResultPanelPictures)));
            IWebElement elementSearchResultPanelPictures = driver.FindElement(By.XPath(searchResultPanelPictures));
            string text3 = elementSearchResultPanelPictures.Text; //  debud
            Assert.AreEqual(elementSearchResultPanelPictures.Text, "Images");
            System.Console.WriteLine("searchResultPanelPictures found:" + elementSearchResultPanelPictures.Text);

            wait.Until(driver => driver.FindElement(By.XPath(searchResultPanelNews)));
            IWebElement elementSearchResultPanelNews = driver.FindElement(By.XPath(searchResultPanelNews));
            string text4 = elementSearchResultPanelNews.Text; //  debud
            Assert.AreEqual(elementSearchResultPanelNews.Text, "News");
            System.Console.WriteLine("searchResultPanelNews found:" + elementSearchResultPanelNews.Text);

            wait.Until(driver => driver.FindElement(By.XPath(searchResultPanelPurchases)));
            IWebElement elementsearchResultPanelVideos = driver.FindElement(By.XPath(searchResultPanelVideos));
            string text6 = elementsearchResultPanelVideos.Text; //  debud
            Assert.AreEqual(elementsearchResultPanelVideos.Text, "Videos");
            System.Console.WriteLine("searchResultPanelPurchases found:" + elementsearchResultPanelVideos.Text);

        }


        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }

    }
}




