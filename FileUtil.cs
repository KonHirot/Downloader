using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader
{
    class FileUtil
    {
        public static string extension = ".png";
        public static string makeFileName(String SavePath)
        {
            // 保存名用に現在の日付と時刻を取得する
            DateTime dt = DateTime.Now;
            string fileName = SavePath + "\\" + dt.ToString("yyyyMMddHHmmss") + extension;
            return fileName;
        }
    }
}
