using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Downloader
{
    class WebManager
    {
        /// <summary>
        /// ドラッグドロップされた画像ファイルのURLを元に画像をダウンロードする
        /// </summary>
        /// <param name="src"></param>
        private void DownloadWebImageFile(String src)
        {
            WebClient client = new WebClient();
            client.DownloadFile(src, FileUtil.makeFileName(Form1.SavePath));
            Console.WriteLine("Download Success!");
        }
    }
}
