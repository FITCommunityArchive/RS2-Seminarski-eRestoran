using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.Client.Util
{
   public class WebAPIHelper
    {
        private HttpClient client { get; set; }
        public string route { get; set; }

        public WebAPIHelper(string uri,string route)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            this.route = route;

        }
        public HttpResponseMessage GetResponse() {

            return client.GetAsync(route).Result;
        }

        public static Image CropImage(Image image, Rectangle rectangle)
        {
            Bitmap bitmap = new Bitmap(image);
            Bitmap btCrop = bitmap.Clone(rectangle, bitmap.PixelFormat);
            return (Image)(btCrop);


        }
        public static Image resizeImage(Image img, Size size)
        {

            int sourceWidth = img.Width;
            int sourceHeight = img.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
            }
            else
            {
                nPercent = nPercentW;
            }

            int destH = (int)(sourceHeight * nPercent);
            int destw = (int)(sourceWidth * nPercent);

            Bitmap b = new Bitmap(destw, destH);
            Graphics graphics = Graphics.FromImage((Image)b);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(img, 0, 0, destw, destH);
            graphics.Dispose();

            return (Image)b;



        }

    }
}
