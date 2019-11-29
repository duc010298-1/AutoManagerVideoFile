using System;
using System.IO;

namespace AutoManagerVideoFile
{
    class FileWatched
    {
        private static readonly string filter = (string) Properties.Settings.Default["videoFilter"];
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
            fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + generateRandomString() + Path.GetExtension(fileName);
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
            Background.trayIcon.BalloonTipText = fileName + "\nClick vào đây để đổi tên file";
            Background.trayIcon.ShowBalloonTip(30000);
        }

        private static string getToday()
        {
            DateTime now = DateTime.Now;
            return now.ToString("dd-MM-yyyy");
        }

        private static string generateRandomString()
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
