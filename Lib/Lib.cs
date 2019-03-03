using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace MyProjectMVC.Lib
{
    public class Lib
    {
        public static Bitmap ResizeImage(Image img, int width)
        {
            var originalW = img.Width;
            var originalH = img.Height;
            var resizedW = width;
            var resizedH = (originalH * resizedW) / originalW;
            var b = new Bitmap(resizedW, resizedH);
            try
            {

                var g = Graphics.FromImage(b);
                g.InterpolationMode = InterpolationMode.Bicubic;    // Specify here
                g.DrawImage(img, 0, 0, resizedW, resizedH);
                g.Dispose();
                //b.Save(path);
                return b;
            }
            catch (Exception)
            {
                return b;
            }

        }
    }
}
