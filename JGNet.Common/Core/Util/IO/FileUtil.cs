using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace JGNet.Common
{
    /// <summary>
    /// 文件工具类
    /// </summary>
    public class FileUtil
    {

        /// <summary>
        /// 获得当前运行程序的路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static String GetProgramRootDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// 通过FileStream 来打开文件，这样就可以实现不锁定Image文件，到时可以让多用户同时访问Image文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Bitmap ReadImageFile(string path)
        {
            FileStream fs = File.OpenRead(path); //OpenRead
            int filelength = 0;
            filelength = (int)fs.Length; //获得文件长度 
            Byte[] image = new Byte[filelength]; //建立一个字节数组 
            fs.Read(image, 0, filelength); //按字节流读取 
            System.Drawing.Image result = System.Drawing.Image.FromStream(fs);
            fs.Close();
            Bitmap bit = new Bitmap(result);
            return bit;
        }

        /// <summary>
        /// 获得该文件夹下的文件，返回类型为FileInfo
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static FileInfo[] GetDirFiles(String path)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] files = root.GetFiles();
            return files;
        }

        /// <summary>
        /// 获得该文件夹下的子目录，返回类型为DirectoryInfo
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DirectoryInfo[] GetDirctorys(String path)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] files = root.GetDirectories();
            return files;
        }


        //选择文件夹：点击【浏览】，选择文件夹
        public static String BrowseFolder(String description=null)
        {
            String folder = string.Empty;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (!String.IsNullOrEmpty(description))
            {
                dialog.Description = description;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.SelectedPath.Trim() != "")
                {
                    folder = dialog.SelectedPath.Trim();
                }
            }
            return folder;
        }
    }
}
