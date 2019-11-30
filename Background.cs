using AutoManagerVideoFile.Properties;
using System;
using System.Windows.Forms;

namespace AutoManagerVideoFile
{
    class Background : ApplicationContext
    {
        public static NotifyIcon trayIcon;
        public static string tempPath;

        public Background()
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.video_file,
                Text = "Quản lý video file",
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Cài đặt", Setting),
                    new MenuItem("Thoát", Exit)
                }),
                BalloonTipTitle = "Phát hiện video mới",
                BalloonTipText = "",
                BalloonTipIcon = ToolTipIcon.Info,
                Visible = true
            };
            trayIcon.DoubleClick += new EventHandler(this.Setting);
            trayIcon.BalloonTipClicked += new EventHandler(this.ChangeFileName);

            ConfigUtil configUtil = new ConfigUtil();
            Config config = configUtil.getConfig();
            if (config == null)
            {
                Setting settingForm = new Setting();
                settingForm.Show();
            }
            else
            {
                FileWatched fileWatched = new FileWatched();
                fileWatched.initWatched(config);
            }  
        }

        void ChangeFileName(object sender, EventArgs e)
        {
            ChangeFileName changeFileName = new ChangeFileName(tempPath);
            changeFileName.Show();
            changeFileName.Activate();
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;
            Application.Exit();
        }

        void Setting(object sender, EventArgs e)
        {
            Setting settingForm = new Setting();
            settingForm.Show();
        }
    }
}
