using System.Drawing;
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