using System.IO;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    public class ChromeTests
    {
        public void PerformTest()
        {
            using (var chrome = new ChromeDriver())
            {
                chrome.Navigate().GoToUrl("http://testing-ground.scraping.pro/login");
                var userNameField = chrome.FindElementById("usr");
                var userPasswordField = chrome.FindElementById("pwd");
                var loginButton = chrome.FindElementByXPath("//input[@value='Login']");

                userNameField.SendKeys("admin");
                userPasswordField.SendKeys("12345");
                loginButton.Click();

                var result = chrome.FindElementByXPath("//div[@id='case_login']/h3").Text;
                File.WriteAllText("result.txt", result);

                chrome.GetScreenshot().SaveAsFile(@"screen.png");
                var array = chrome.GetScreenshot().AsByteArray;
                var imagea = ImageTools.ToImage(array);
            }
        }
    }
}