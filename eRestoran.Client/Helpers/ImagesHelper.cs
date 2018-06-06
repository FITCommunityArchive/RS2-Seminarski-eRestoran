using System.Drawing;
using System.IO;

namespace eRestoran.Client.Helpers
{
    public static class ImagesHelper
    {
        private static string imagesFolderPath = Path.GetFullPath("~/../../../Images/");
        public static Image GetImage(string imageName, int width = 100, int height = 100)
        {
            return new Bitmap(Image.FromFile(imagesFolderPath + imageName), new Size(width, height));
        }
    }
}
