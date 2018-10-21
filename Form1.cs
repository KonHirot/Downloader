using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace Downloader
{
    public partial class Form1 : Form
    {
        // ファイル保存先
        public static string SavePath = "";
        public const string FileLocationTextName = "\\saveFileLocation.txt";
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

        /// <summary>
        /// 画像のファイル保存先を設定
        /// </summary>
        private void GetsavePath() {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            // テキストに記載されたファイル保存先を読み込む
            using (StreamReader sr =
                new StreamReader(currentDir + FileLocationTextName, Encoding.GetEncoding("SHIFT_JIS")))
            { 
                while (sr.EndOfStream == false)
                {
                    // 一行目にパスが記載されているのみ
                    SavePath = sr.ReadLine();
                }
            }
        }


        /// <summary>
        /// 画像がアプリにドラッグドロップされたとき、画像を保存する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // string src = e.Data.GetData(DataFormats.Text).ToString();
                // DownloadWebImageFile(src);

                // tmpファイルのパスを取得
                var bmp = e.Data.GetData(DataFormats.FileDrop);
                // オブジェクト配列のためCast
                string[] bmpPath = (string[])bmp;
                FileManager fm = new FileManager();
                // pathは一つのみ
                foreach(string path in bmpPath)
                {
                    fm.saveBmpFile(path);
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
    }
}
