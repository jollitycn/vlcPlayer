namespace CJBasic.Loggers
{
    using CJBasic.Helpers;
    using System;
    using System.IO;

    public class FileLogger : ILogger, IDisposable
    {
        private bool enabled = true;
        private string iniPath;
        private long maxLength = 0x7fffffffffffffffL;
        private StreamWriter writer;

        public FileLogger(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            this.iniPath = filePath;
            this.writer = new StreamWriter(File.Open(filePath, FileMode.Append, FileAccess.Write, FileShare.Read));
        }

        private void CheckAndChangeNewFile()
        {
            if (this.writer.BaseStream.Length >= this.maxLength)
            {
                this.writer.Close();
                this.writer = null;
                string fileNameNoPath = FileHelper.GetFileNameNoPath(this.iniPath);
                string fileDirectory = FileHelper.GetFileDirectory(this.iniPath);
                int length = fileNameNoPath.LastIndexOf('.');
                string str3 = null;
                string str4 = fileNameNoPath;
                if (length >= 0)
                {
                    str3 = fileNameNoPath.Substring(length + 1);
                    str4 = fileNameNoPath.Substring(0, length);
                }
                string path = null;
                for (int i = 1; i < 0x3e8; i++)
                {
                    string str6 = str4 + "_" + i.ToString("000");
                    if (str3 != null)
                    {
                        str6 = str6 + "." + str3;
                    }
                    path = fileDirectory + @"\" + str6;
                    if (!File.Exists(path))
                    {
                        break;
                    }
                    FileInfo info = new FileInfo(path);
                    if (info.Length < this.maxLength)
                    {
                        break;
                    }
                }
                this.writer = new StreamWriter(File.Open(path, FileMode.Append, FileAccess.Write, FileShare.Read));
            }
        }

        private void Close()
        {
            if (this.writer != null)
            {
                try
                {
                    this.writer.Close();
                    this.writer = null;
                }
                catch
                {
                }
            }
        }

        public void Dispose()
        {
            this.Close();
            GC.SuppressFinalize(this);
        }

        ~FileLogger()
        {
            this.Close();
        }

        public void Log(string msg)
        {
            if (this.enabled)
            {
                lock (this.writer)
                {
                    this.writer.WriteLine(msg + "\n");
                    this.writer.Flush();
                    this.CheckAndChangeNewFile();
                }
            }
        }

        public void LogWithTime(string msg)
        {
            string str = string.Format("{0} : {1}", DateTime.Now.ToString(), msg);
            this.Log(str);
        }

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

        public long MaxLength4ChangeFile
        {
            get
            {
                return this.maxLength;
            }
            set
            {
                if (value <= 0L)
                {
                    throw new ArgumentOutOfRangeException("MaxLength4ChangeFile must greater than 0.");
                }
                this.maxLength = value;
            }
        }
    }
}

