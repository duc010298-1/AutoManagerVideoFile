using AutoManagerVideoFile.Properties;
using System;
using System.Windows.Forms;

namespace AutoManagerVideoFile
{
    class Background : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public Background()
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.video_file,
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Cài đặt", Setting),
                    new MenuItem("Thoát", Exit)
                }),
                Visible = true
            };

            ConfigUtil configUtil = new ConfigUtil();
            Config config = configUtil.getConfig();
            if (config == null)
            {
                Setting settingForm = new Setting();
                settingForm.Show();
            }
            else
            {
                FileWatched.initWatched(config);
            }  
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
