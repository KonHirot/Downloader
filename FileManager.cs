using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader
{
    class FileManager
    {
        private void copyFile(String path)
        {
            File.Copy(path, FileUtil.makeFileName(Form1.SavePath));
            Console.WriteLine("Download Success!");
        }

        /// <summary>
        /// bmpを変換して保存する
        /// </summary>
        /// <param name="bmpPath"></param>
        public void saveBmpFile(String bmpPath)
        {
            using (Image image = Image.FromFile(bmpPath))
            using (Image clone = new Bitmap(image))
            {
                clone.Save(FileUtil.makeFileName(Form1.SavePath), ImageFormat.Png);
            }
            Console.WriteLine("Download Success!");
        }

    }
}
