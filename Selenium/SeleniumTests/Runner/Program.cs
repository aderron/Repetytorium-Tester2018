using System.Drawing;
using SeleniumTests;

namespace Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CompareImages();
        }

        private static void CompareImages()
        {
            var bitmapA = new Bitmap("s1.png");
            var bitmapB = new Bitmap("s2.png");

            var output = ImageTools.CompareImages(bitmapA, bitmapB);

            output.Save("output.png");
        }
    }
}