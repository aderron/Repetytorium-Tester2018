using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace SeleniumTests
{
    public static class BrowserTests
    {
        public static void ChromeLoginOnTestPage()
        {
            using (var chrome = new ChromeDriver())
            {
                LoginOnTestPage(chrome, "screen-chrome");
            }
        }

        public static void FirefoxLoginOnTestPage()
        {
            using (var firefox = new FirefoxDriver())
            {
                LoginOnTestPage(firefox, "screen-firefox");
            }
        }

        public static void IeLoginOnTestPage()
        {
            using (var ie = new InternetExplorerDriver())
            {
                LoginOnTestPage(ie, "screen-ie");
            }
        }

        public static void LoginOnTestPage(
            RemoteWebDriver driver, 
            string screenshotName)
        {
            // Go to the home page
            driver.Navigate().GoToUrl("http://testing-ground.scraping.pro/login");

            // Get the page elements
            var userNameField = driver.FindElementById("usr");
            var userPasswordField = driver.FindElementById("pwd");
            var loginButton = driver.FindElementByXPath("//input[@value='Login']");

            // Type user name and password
            userNameField.SendKeys("admin");
            userPasswordField.SendKeys("12345");

            // and click the login button
            loginButton.Click();

            // Extract the text and save it into result.txt
            var result = driver.FindElementByXPath("//div[@id='case_login']/h3").Text;
            File.WriteAllText(screenshotName + ".txt", result);

            // Take a screenshot and save it into screen.png
            driver.GetScreenshot().SaveAsFile(screenshotName + ".png");
        }
    }
}
