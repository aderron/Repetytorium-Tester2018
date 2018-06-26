using System.Drawing;
using System.IO;
using NUnit.Framework;
using SeleniumTests;

namespace Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BrowserTests.ChromeLoginOnTestPage("screen-chrome");
            BrowserTests.FirefoxLoginOnTestPage("screen-firefox");
            BrowserTests.IeLoginOnTestPage("screen-edge");

            CompareImages("screen-chrome.png", "screen-firefox.png", "chrome-firefox.png");
            CompareImages("screen-chrome.png", "screen-edge.png", "chrome-edge.png");

            var chromeLoggedIn = File.ReadAllText("screen-chrome.txt");
            var firefoxLoggedIn = File.ReadAllText("screen-firefox.txt");
            var ieLoggedIn = File.ReadAllText("screen-edge.txt");

            Assert.AreEqual("WELCOME :)", chromeLoggedIn);
            Assert.AreEqual("WELCOME :)", firefoxLoggedIn);
            Assert.AreEqual("WELCOME :)", ieLoggedIn);
        }

        private static void CompareImages(string inputA, string inputB, string outputName)
        {
            var bitmapA = new Bitmap(inputA);
            var bitmapB = new Bitmap(inputB);

            var output = ImageTools.CompareImages(bitmapA, bitmapB);

            output.Save(outputName);
        }
    }
}