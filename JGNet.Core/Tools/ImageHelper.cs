using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;

using System.Text;


namespace JGNet.Core
{
    public class ImageHelper
    {
        /// <summary>
        /// 获取指定最大长度/高度的图片，小于就不变 (以长边做maxSize)
        /// </summary>
        /// <param name="img">原图</param>
        /// <param name="maxSize">新尺寸</param>
        /// <returns></returns>
        public static Image GetNewSizeImage(Image img, int maxSize)
        {
            Image map = null;
            if (img.Width > maxSize && img.Height > maxSize)
            {
                if (img.Width > img.Height)
                {
                    int width = maxSize;
                    int height = Convert.ToInt32(img.Height * (1.0 * width / img.Width));
                    //  map = CJBasic.Helpers.ImageHelper.Zoom(img, new Size() { Height = height, Width = width });
                    //  map = img.GetThumbnailImage(height, width, null, new IntPtr());
                    map = img.GetThumbnailImage(width, height, null, new IntPtr());
                   //map = img.GetThumbnailImage(img.Width, img.Height, null, new IntPtr());
                }
                else
                {
                    int height = maxSize;
                    int width = Convert.ToInt32(img.Width * (1.0 * height / img.Height));
                    //  map = img.GetThumbnailImage(height, width, null, new IntPtr());
                    map = img.GetThumbnailImage(width,height,  null, new IntPtr());
                }
            }
            else if (img.Width > maxSize)
            {
                int width = maxSize;
                int height = Convert.ToInt32(img.Height * (1.0 * width / img.Width));
                // map = img.GetThumbnailImage(height, width, null, new IntPtr());

                map = img.GetThumbnailImage( width, height, null, new IntPtr());
            }
            else if (img.Height > maxSize)
            {
                int height = maxSize;
                int width = Convert.ToInt32(img.Width * (1.0 * height / img.Height));
                // map = img.GetThumbnailImage(height, width, null, new IntPtr());
                map = img.GetThumbnailImage( width,height, null, new IntPtr());
            }
            else
            {
                map = img;

            }

            return map;
        }

        /// <summary>
        /// 获取指定最大长度/高度的图片，小于就不变  (以短边做maxSize)
        /// </summary>
        /// <param name="img">原图</param>
        /// <param name="maxSize">新尺寸</param>
        /// <returns></returns>
        public static Image GetNewSizeImage2(Image img, int maxSize)
        {
            Image map = null;
            if (img.Width > maxSize && img.Height > maxSize)
            {
                if (img.Width > img.Height)
                {
                    int height = maxSize;
                    int width = Convert.ToInt32(img.Width * (1.0 * height / img.Height));
                    map = img.GetThumbnailImage(width, height, null, new IntPtr());
                }
                else
                {
                    int width = maxSize;
                    int height = Convert.ToInt32(img.Height * (1.0 * width / img.Width));
                    //  map = CJBasic.Helpers.ImageHelper.Zoom(img, new Size() { Height = height, Width = width });
                    map = img.GetThumbnailImage(width, height, null, new IntPtr());
                }
            }
            else if (img.Width > maxSize)
            {
                int height = maxSize;
                int width = Convert.ToInt32(img.Width * (1.0 * height / img.Height));
                map = img.GetThumbnailImage(width, height, null, new IntPtr());
            }
            else if (img.Height > maxSize)
            {
                int width = maxSize;
                int height = Convert.ToInt32(img.Height * (1.0 * width / img.Width));
                map = img.GetThumbnailImage(width, height, null, new IntPtr());
            }
            else
            {
                map = img;
            }
            return map;
        }

        /// <summary>
        /// 解决IMAGE FROM FILE 文件被占用的问题
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Image FromFileStream(String filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            int byteLength = (int)fileStream.Length;
            byte[] fileBytes = new byte[byteLength];
            fileStream.Read(fileBytes, 0, byteLength);
            //文件流关闭,文件解除锁定
            fileStream.Close();
            return Image.FromStream(new MemoryStream(fileBytes));
        }
        public static byte[] ImageToBytes(Image image)
        {

            byte[] photo = null;
            if (image != null)
            {
                MemoryStream stream = new MemoryStream();
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                photo = stream.ToArray();

            }
            return photo;
        }


        /// <summary>
        /// 直接用皮肤空间就有
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Image BytesToImage(byte[] bytes)
        {

            Image image = null;
            if (bytes != null)
            {
                MemoryStream stream = new MemoryStream(bytes);
                image = new Bitmap(stream);
            }
            return image;
        }

        /// <summary>
        /// 将byte数组转化为图片Image
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Image BytesToImage2(byte[] bytes)
        {
            Image image = null;
            if (bytes != null)
            {
                MemoryStream ms = new MemoryStream(bytes);
                image = Image.FromStream(ms);
            }             
            return image;
        }

        public static Image StreamToImage(Stream stream)
        {
            Image image = null;
            if (stream != null)
            {
                image = Image.FromStream(stream);
            }
            return image;
        }

        /// <summary>
        /// 根据长时间获取最新的文件名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetNewFileName(string fileName)
        {
            String fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            String extension = Path.GetExtension(fileName);
            String newFileName = fileNameWithoutExtension + DateTime.Now.Ticks + extension;
            return newFileName;
        }

        public static string GetNewFileName(string fileName, int size)
        {
            String fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            String extension = Path.GetExtension(fileName);
            String newFileName = fileNameWithoutExtension + "_" + size + extension;
            return newFileName;
        }

        public static string GetNewFileName(String costumeID, string fileName)
        {
            //  String fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            String extension = Path.GetExtension(fileName);
            String newFileName = costumeID + "_" + ImageHelper.TimeStr() + extension;
            return newFileName;
        }

        private static Random ran = new Random();
        private static object lockObj = new object();
        private static string TimeStr()
        {
            lock (ImageHelper.lockObj)
            {
                int RandKey = ran.Next(100, 999);
                return String.Format("{0:yyyyMMddHHmmssff}", DateTime.Now) + RandKey;
            }
        }

        public static string GetNewJpgName(string costumeID)
        {
            return costumeID + "_" + ImageHelper.TimeStr() + ".jpg";
        }
        public static string GetNewImageName(string costumeID, string imgExtType)
        { 
            return costumeID + "_" + ImageHelper.TimeStr() + imgExtType;
        }

        /// 将图片按百分比压缩，flag取值1到100，越小压缩比越大
        public static bool Compress(Image iSource, string outPath, int flag)
        {
            ImageFormat tFormat = iSource.RawFormat;
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageDecoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {

                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }

                if (jpegICIinfo != null)
                {
                    iSource.Save(outPath, jpegICIinfo, ep);
                }
                else
                {
                    iSource.Save(outPath, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }

            //   iSource.Dispose();

        }

        /// <summary>
        /// 直接调用image.Save，可能发生A generic error occurred in GDI+异常
        /// </summary>
        /// <param name="image"></param>
        /// <param name="outputFileName"></param>
        public static void SavePhoto(Image image, string outputFileName)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    image.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        }

        public static byte[] ToByteArray(Image image)
        {
            byte[] bytes;
            using (MemoryStream memory = new MemoryStream())
            {
                image.Save(memory, ImageFormat.Jpeg);
                bytes = memory.ToArray();
            }
            return bytes;
        }
    }


    public class FileHelper
    {

    }
}
