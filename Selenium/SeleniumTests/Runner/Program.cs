using System.Drawing;
using SeleniumTests;

namespace Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var x = new ChromeTests();
            //x.PerformTest();
            var a = "s1.png";
            var b = "s2.png";

            var bitmapA = new Bitmap(a);
            var bitmapB = new Bitmap(b);

            var output = ImageTools.CompareImages(bitmapA, bitmapB);

            output.Save("output.png");
        }
    }
}