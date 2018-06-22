using System.Drawing;
using System.IO;

namespace SeleniumTests
{
    public static class ImageTools
    {
        public static Bitmap CompareImages(Bitmap a, Bitmap b)
        {
            var bitmap = new Bitmap(a.Width, a.Height);

            for (var column = 0; column < a.Height; column++)
            {
                for (var row = 0; row < a.Width; row++)
                {
                    var aPixel = a.GetPixel(row, column);
                    var bPixel = b.GetPixel(row, column);

                    var outputColor = aPixel == bPixel ? Grayscale(aPixel) : CompareColors(aPixel, bPixel);
                    bitmap.SetPixel(row, column, outputColor);
                }
            }

            return bitmap;
        }

        public static Color Grayscale(Color a)
        {
            var aWeight = (a.R + a.G + a.B) / 3;
            var lightenColor = (255 - aWeight) / 2 + aWeight;
            return Color.FromArgb(lightenColor, lightenColor, lightenColor);
        }

        public static Color CompareColors(Color a, Color b)
        {
            var aWeight = a.R + a.G + a.B;
            var bWeight = b.R + b.G + b.B;

            if (aWeight > bWeight)
            {
                return Color.FromArgb(aWeight / 3, 0, 0);
            }

            return Color.FromArgb(0, bWeight / 3, 0);
        }

        public static Image ToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}