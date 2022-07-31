using System;
using System.Collections.Generic;
using System.Threading;
using HealthDemoTest.WatersPeregrineHealthPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace HealthDemoTest
{
    [TestClass]
    public class BaseClass
    {
        private static IWebDriver driver;
        private static SelectElement select;

        static BaseClass()
        {
            driver = null;
            select = null;
        }
        public static void LaunchBrowser(string browser)
        {
            switch (browser)
            {
                case "Chrome":
                    driver = InitChrome();
                    break;
                case "Firefox":
                    driver = InitFirefox();
                    break;
                default:
                    Console.WriteLine(browser + " is not recognised. so, Firefox is launched instead");
                    driver = InitFirefox();
                    break;
            }
            driver.Manage().Window.Maximize();
        }
        private static IWebDriver InitChrome()
        {
            driver = new ChromeDriver();
            return driver;
        }
        private static IWebDriver InitFirefox()
        {
            driver = new FirefoxDriver();
            return driver;
        }
        public static void LaunchUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public static void CloseBrowser()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Close();
            driver.Quit();
        }
        public static void SelectByIndex(IWebElement element, int index)
        {
            select = new SelectElement(element);
            select.SelectByIndex(index);
        }
        public static void SelectByText(IWebElement element, string text)
        {
            select = new SelectElement(element);
            select.SelectByText(text);
        }
        public static void SelectByValue(IWebElement element, string value)
        {
            select = new SelectElement(element);
            select.SelectByValue(value);
        }
        public static IWebElement GetWebElementById(string id)
        {
            By locator = By.Id(id);
            return GetElement(locator);
        }
        public static IWebElement GetWebElementByClassName(string classname)
        {
            By locator = By.ClassName(classname);
            return GetElement(locator);
        }
        public static IWebElement GetWebElementByCSSSelector(string cssselector)
        {
            By locator = By.CssSelector(cssselector);
            return GetElement(locator);
        }
        public static IWebElement GetWebElementByXpath(string xpath)
        {
            By locator = By.XPath(xpath);
            return GetElement(locator);
        }
        public static IWebElement GetWebElementByName(string name)
        {
            By locator = By.Name(name);
            return GetElement(locator);
        }
        public static IList<IWebElement> GetWebElementsById(string id)
        {
            By locator = By.Id(id);
            return GetElements(locator);
        }
        public static IList<IWebElement> GetWebElementsByClassName(string classname)
        {
            By locator = By.ClassName(classname);
            return GetElements(locator);
        }
        public static IList<IWebElement> GetWebElementsByCSSSelector(string cssselector)
        {
            By locator = By.CssSelector(cssselector);
            return GetElements(locator);
        }
        public static IList<IWebElement> GetWebElementsByXpath(string xpath)
        {
            By locator = By.XPath(xpath);
            return GetElements(locator);
        }
        public static IList<IWebElement> GetWebElemenstByName(string name)
        {
            By locator = By.Name(name);
            return GetElements(locator);
        }
        private static IWebElement GetElement(By locator)
        {
            IWebElement element = null;
            int tryCount = 0;
            while (element == null)
            {
                try
                {
                    element = driver.FindElement(locator);
                }
                catch (Exception e)
                {
                    if (tryCount == 3)
                    {
                        throw e;
                    }
                }
                var waitTime = new TimeSpan(0, 0, 2);
                Thread.Sleep(waitTime);

                tryCount++;
            }
            Console.WriteLine(element.ToString() + "is now retrieved");
            return element;
        }
        private static IList<IWebElement> GetElements(By locator)
        {
            IList<IWebElement> elements = null;
            int tryCount = 0;
            while (elements == null)
            {
                try
                {
                    elements = driver.FindElements(locator);
                }
                catch (Exception e)
                {
                    if (tryCount == 7)
                    {
                        throw e;
                    }
                }
                var waitTime = new TimeSpan(0, 0, 5);
                Thread.Sleep(waitTime);

                tryCount++;
            }
            Console.WriteLine(elements.ToString() + "is now retrieved");
            return elements;
        }
        private static Screenshot TakeScreenshot()
        {
            return ((ITakesScreenshot)driver).GetScreenshot();
        }
        private static void  SaveScreenshot()
        {
            try
            {
                var dateNow = DateTime.Now.Date.ToString().Replace(@"/", "").Replace(@" ", "").Replace(@":", "");
                dateNow = dateNow.Substring(0, 8);

                var timeNow = DateTime.Now.TimeOfDay.ToString().Replace(@"/", "").Replace(@" ", "").Replace(@":", "").Replace(@".", "");
                timeNow = timeNow.Substring(0, 6);

                var fileName = String.Format("C:\\Screenshots\\{0}_{1}", dateNow, timeNow);

                var screenshot = TakeScreenshot();

                screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
       
             }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Screenshot cannot be written saved because of {0}", e));
            }
        }

        public void SwitchToTab(int tab)
        {
            // var js = (IJavaScriptExecutor)driver;
            // js.ExecuteScript("window.open();");
            // IList<string> tabs = new List<string>(driver.WindowHandles);
            // driver.SwitchTo().Window(tabs[tab]);

            var popup = driver.WindowHandles[1]; // handler for the new tab
            Assert.IsTrue(!string.IsNullOrEmpty(popup)); // tab was opened
           // Assert.AreEqual(driver.SwitchTo().Window(popup).Url, "http://blah"); // url is OK  
           // driver.SwitchTo().Window(driver.WindowHandles[0]).Close(); // close the tab
            driver.SwitchTo().Window(driver.WindowHandles[tab]); // get back to the main window
        }
        public static WatersIodHomePage GivenINavigateToWatersIodHomePage()
        {
            LaunchUrl("http://iod.devtools.waters.com/instruments");
            return new WatersIodHomePage();
        }
    }
}

    