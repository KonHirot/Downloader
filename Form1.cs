using System;
using System.Drawing;
using System.Drawing.Imaging;
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
        public static string extension = ".png";
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
                SavePath = sr.ReadLine();
            }
        }



        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // string src = e.Data.GetData(DataFormats.Text).ToString();
                // DownloadWebImageFile(src);

                // 

                // tmpファイルのパスを取得
                var bmp = e.Data.GetData(DataFormats.FileDrop);
                // オブジェクト配列のためCast
                string[] bmpPath = (string[])bmp;
                // pathは一つのみ
                foreach(string str in bmpPath)
                {
                    saveBmpFile(str);
                } 
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

        private void copyFile(String path) {
            File.Copy(path, makeFileName());
        }

        /// <summary>
        /// bmpを変換して保存する
        /// </summary>
        /// <param name="bmpPath"></param>
        private void saveBmpFile(String bmpPath)
        {
            using (Image image = Image.FromFile(bmpPath))
            using (Image clone = new Bitmap(image))
            {
                clone.Save(makeFileName(), ImageFormat.Png);
            }
            Console.WriteLine("Download Success!");
        }

        private void DownloadWebImageFile(String src) {
            WebClient client = new WebClient();
            client.DownloadFile(src, makeFileName());
            Console.WriteLine("Download Success!");
        }

        private string makeFileName() {
            // 保存名用に現在の日付と時刻を取得する
            DateTime dt = DateTime.Now;
            string fileName = SavePath + "\\" + dt.ToString("yyyyMMddHHmmss") + extension;
            return fileName;
        }
    }
}
