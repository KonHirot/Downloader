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
        private void DownloadWebImageFile(String src)
        {
            WebClient client = new WebClient();
            client.DownloadFile(src, FileUtil.makeFileName(Form1.SavePath));
            Console.WriteLine("Download Success!");
        }
    }
}
