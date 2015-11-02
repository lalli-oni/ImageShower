using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ImageShower.Models;

namespace ImageShower
{
    class Downloader
    {
        public ImageModel DownloadImage(string url)
        {
            using (WebClient client = new WebClient())
            {
                byte[] data = client.DownloadData(url);

                using (MemoryStream mem = new MemoryStream(data))
                {
                    using (var yourImage = Image.FromStream(mem))
                    {
                        ImageModel outputImage = new ImageModel() { Image = ConvertImage(yourImage), IsPosted = true};
                        return outputImage;
                    }
                }
            }
            return null;
        }

        public ImageSource ConvertImage(object value)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)value).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();

            return image;
        }
    }
}
