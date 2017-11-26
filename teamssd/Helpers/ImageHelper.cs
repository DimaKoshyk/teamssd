using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace teamssd.Helpers
{
    public static class ImageHelper
    {
        public static string ConvertToBase64String(HttpPostedFileBase imageFileBase)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                imageFileBase.InputStream.CopyTo(memory);
                byte[] data = memory.ToArray();
                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(data);

                return base64String;
            }
        }

        //private static string ResizeImg()
        //{
        //    Image image = Image.FromStream(file.InputStream);
        //    var source = new Bitmap(image);

        //    int startPointY;
        //    int startPointX;
        //    int newHeight;

        //    Stream stream = image.Width > image.Height ? ImageHelper.ResizeImageWidth(source, 1280, ImageFormat.Jpeg) : ImageHelper.ResizeImageHeight(source, 1080, ImageFormat.Jpeg);

        //    var originalImageBlob = AzureBlobHelper.GetImageBlob(originalImageUri);
        //    originalImageBlob.UploadFromStream(stream);

        //    if (source.Height > source.Width)
        //    {
        //        startPointY = (source.Height - source.Width) / 2;
        //        startPointX = 0;
        //        newHeight = source.Width;
        //    }
        //    else if (source.Height < source.Width)
        //    {
        //        startPointY = 0;
        //        startPointX = (source.Width - source.Height) / 2;
        //        newHeight = source.Height;
        //    }
        //    else
        //    {
        //        startPointY = 0;
        //        startPointX = 0;
        //        newHeight = source.Height;
        //    }

        //    var rectangle = new Rectangle(startPointX, startPointY, newHeight, newHeight);
        //    Bitmap bitmapImage = source.Clone(rectangle, source.PixelFormat);
        //}
        //public static Stream ResizeImageWidth(Bitmap bitmap, int width, ImageFormat imageFormat)
        //{
        //    var image = ScaleImageWidth(bitmap, width);
        //    return SaveImageToStream(image, imageFormat);
        //}
        //public static Stream ResizeImageHeight(Bitmap bitmap, int height, ImageFormat imageFormat)
        //{
        //    var image = ScaleImageHeight(bitmap, height);
        //    return SaveImageToStream(image, imageFormat);
        //}

        //public static Image ScaleImageWidth(Image image, int maxWidth)
        //{
        //    return ScaleImage(image, (double)maxWidth / image.Width);
        //}

        //public static Image ScaleImageHeight(Image image, int maxHeight)
        //{
        //    return ScaleImage(image, (double)maxHeight / image.Height);
        //}

        //public static Image ScaleImage(Image image, double ratio)
        //{
        //    var newWidth = (int)(image.Width * ratio);
        //    var newHeight = (int)(image.Height * ratio);

        //    var newImage = new Bitmap(newWidth, newHeight);
        //    Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
        //    return newImage;
        //}

        //private static Stream SaveImageToStream(Image image, ImageFormat imageFormat)
        //{
        //    var newImageStream = new MemoryStream();
        //    image.Save(newImageStream, imageFormat ?? ImageFormat.Jpeg);
        //    newImageStream.Seek(0, SeekOrigin.Begin);
        //    return newImageStream;
        //}
    }
}