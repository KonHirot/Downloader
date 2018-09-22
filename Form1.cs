using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
namespace Downloader
{
    public partial class Form1 : Form
    {
        // ファイル保存先
        public static string SavePath = "";
        public const string FileLocationTextName = "\\saveFileLocation.txt";
        public static string extension = ".jpg";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ファイル保存先を取得する
            GetsavePath();
            Console.WriteLine("success read " + SavePath);
        }

        private void GetsavePath() {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            // テキストに記載されたファイル保存先を読み込む
            StreamReader sr = 
                new StreamReader(currentDir + FileLocationTextName, Encoding.GetEncoding("SHIFT_JIS"));
            while (sr.EndOfStream == false)
            {
                // 一行目にパスが記載されているのみ
                SavePath = @sr.ReadLine();
            }
        }



        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // string src = e.Data.GetData(DataFormats.Text).ToString();
                var src = e.Data.GetData(DataFormats.).ToString();
                Console.WriteLine(src);
                DownloadWebImageFile(src);
            }
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void DownloadWebImageFile(String src) {
            // 保存名用に現在の日付と時刻を取得する
            DateTime dt = DateTime.Now;
            string fileName = SavePath + "\\" + dt.ToString("yyyyMMddHHmmss") + extension;

            WebClient client = new WebClient();
            client.UseDefaultCredentials = true;
            client.DownloadFile(src, fileName);
            Console.WriteLine("Download Success!");

        }
    }
}
