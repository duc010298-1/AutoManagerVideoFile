using NReco.VideoConverter;
using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace AutoManagerVideoFile
{
    class FileWatched
    {
        private readonly string filter = "*.ts";
        public FileSystemWatcher watcher;
        public Config config;
        private BackgroundWorker backgroundWorker;
        private string fromPath;
        private string toPath;
        private string oldPath;
        private Queue queue = new Queue();
        public void initWatched(Config c)
        {
            config = c;
            if (watcher != null)
            {
                watcher.EnableRaisingEvents = false;
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Dispose();
            }
            watcher = new FileSystemWatcher()
            {
                Path = config.InputDirectory,
                Filter = filter
            };
            // Add event handlers for all events you want to handle
            watcher.Created += new FileSystemEventHandler(OnChanged);
            // Activate the watcher
            watcher.EnableRaisingEvents = true;

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += doWork;
            backgroundWorker.RunWorkerCompleted += workerComplete;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Background.trayIcon.BalloonTipClicked -= new EventHandler(ChangeFileName);
            Background.trayIcon.BalloonTipTitle = "Phát hiện video mới";
            Background.trayIcon.BalloonTipText = "Đang trong quá trình xử lý, vui lòng đợi thông báo";
            Background.trayIcon.ShowBalloonTip(30000);
            if (backgroundWorker.IsBusy)
            {
                queue.Enqueue(e);
            }
            else
            {
                moveFile(e.FullPath, e.Name);
            }
        }

        private void moveFile(string from, string fileName)
        {
            fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + generateRandomString() + ".mp4";
            string path = Path.Combine(config.OutDirectory, getToday());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            fromPath = from;
            toPath = path;
            backgroundWorker.RunWorkerAsync();
        }

        private void doWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                ffMpeg.ConvertMedia(fromPath, toPath, Format.mp4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Lỗi! File chưa được di chuyển", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void workerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            oldPath = toPath;
            Background.trayIcon.BalloonTipClicked -= new EventHandler(ChangeFileName);
            Background.trayIcon.BalloonTipClicked += new EventHandler(ChangeFileName);
            Background.trayIcon.BalloonTipTitle = "Thông báo";
            Background.trayIcon.BalloonTipText = Path.GetFileName(toPath) + "\nClick vào đây để đổi tên file";
            Background.trayIcon.ShowBalloonTip(30000);
            if (File.Exists(fromPath))
            {
                File.Delete(fromPath);
            }
            if (queue.Count != 0)
            {
                FileSystemEventArgs fileSystemEvent = (FileSystemEventArgs) queue.Dequeue();
                moveFile(fileSystemEvent.FullPath, fileSystemEvent.Name);
            }
        }

        private string getToday()
        {
            DateTime now = DateTime.Now;
            return now.ToString("dd-MM-yyyy");
        }

        public static string generateRandomString()
        {
            var chars = "0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        private void ChangeFileName(object sender, EventArgs e)
        {
            ChangeFileName changeFileName = new ChangeFileName(oldPath);
            changeFileName.Show();
            changeFileName.Activate();
        }
    }
}
