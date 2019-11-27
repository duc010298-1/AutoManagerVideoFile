using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoManagerVideoFile
{
    class FileWatched
    {
        private static readonly string filter = "*.txt";
        public static FileSystemWatcher watcher;
        public static Config config;
        public static void initWatched(Config c)
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

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            moveFile(e.FullPath, e.Name);
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }

        private static void moveFile(string from, string fileName)
        {
            string path = Path.Combine(config.OutDirectory + "\\" + getToday());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path + "\\" + fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.Move(from, path);
            showNotify(path);
        }

        private static string getToday()
        {
            DateTime now = DateTime.Now;
            return now.ToString("dd-MM-yyyy");
        }

        private static void showNotify(string fileMovedPath)
        {
            var notification = new System.Windows.Forms.NotifyIcon()
            {
                Visible = true,
                Icon = System.Drawing.SystemIcons.Information,
                BalloonTipTitle = "Balloon Tip Title",
                BalloonTipText = "Phát hiện video mới",
                BalloonTipIcon = ToolTipIcon.Error
            };

            notification.ShowBalloonTip(30000);
        }
    }
}
