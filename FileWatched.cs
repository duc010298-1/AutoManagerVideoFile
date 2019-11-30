using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AutoManagerVideoFile
{
    class FileWatched
    {
        private readonly string filter = "*.mp4";
        public FileSystemWatcher watcher;
        public Config config;
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
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            moveFile(e.FullPath, e.Name);
        }

        private void moveFile(string from, string fileName)
        {
            fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + generateRandomString() + Path.GetExtension(fileName);
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
            try
            {
                Thread.Sleep(500);
                File.Move(from, path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Lỗi! File chưa được di chuyển", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Background.tempPath = path;
            Background.trayIcon.BalloonTipText = fileName + "\nClick vào đây để đổi tên file";
            Background.trayIcon.ShowBalloonTip(30000);
        }

        private string getToday()
        {
            DateTime now = DateTime.Now;
            return now.ToString("dd-MM-yyyy");
        }

        public string generateRandomString()
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
    }
}
