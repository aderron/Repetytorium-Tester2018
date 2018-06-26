using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SeleniumTests
{
    public static class BrowserTests
    {
        public static void ChromeLoginOnTestPage()
        {
            using (var chrome = new ChromeDriver())
            {
                // Go to the home page
                chrome.Navigate().GoToUrl("http://testing-ground.scraping.pro/login");

                // Get the page elements
                var userNameField = chrome.FindElementById("usr");
                var userPasswordField = chrome.FindElementById("pwd");
                var loginButton = chrome.FindElementByXPath("//input[@value='Login']");

                // Type user name and password
                userNameField.SendKeys("admin");
                userPasswordField.SendKeys("12345");

                // and click the login button
                loginButton.Click();

                // Extract the text and save it into result.txt
                var result = chrome.FindElementByXPath("//div[@id='case_login']/h3").Text;
                File.WriteAllText("result.txt", result);

                // Take a screenshot and save it into screen.png
                chrome.GetScreenshot().SaveAsFile(@"screen-chrome.png");
            }
        }

        public static void FirefoxLoginOnTestPage()
        {
            using (var firefox = new FirefoxDriver())
            {
            }
        }

        public static void IeLoginOnTestPage()
        {
            using (var ie = new InternetExplorerDriver())
            {
            }
        }
    }
}
