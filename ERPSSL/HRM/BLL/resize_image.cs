using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

/// <summary>
/// Summary description for resize_image
/// </summary>
public class resize_image
{
	public resize_image()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool GenerateThumbnails(double scaleFactor, Stream OriginalimageFile, string outputFile)
    {
        using (var image = Image.FromStream(OriginalimageFile))
        {
            var newWidth = (int)(image.Width * scaleFactor);
            var newHeight = (int)(image.Height * scaleFactor);

            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            {
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(outputFile, image.RawFormat);
            }
            return true;
        }
    }
}