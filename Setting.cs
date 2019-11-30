using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace AutoManagerVideoFile
{
    public partial class Setting : Form
    {
        Config config;
        public Setting()
        {
            InitializeComponent();
            ConfigUtil configUtil = new ConfigUtil();
            config = configUtil.getConfig();
            if (config == null)
            {
                config = new Config();
            }
            else
            {
                txtInputDirectory.Text = config.InputDirectory;
                txtOutputDirectory.Text = config.OutDirectory;
                btnSaveSetting.Enabled = true;
            }
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            if (registryKey.GetValue("AutoManagerVideoFile") == null)
            {
                checkBoxStartWithWindows.Checked = false;
            }
            else
            {
                checkBoxStartWithWindows.Checked = true;
            }
        }

        private void btnInputDirectory_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                txtInputDirectory.Text = folderBrowserDialog.SelectedPath;
                config.InputDirectory = folderBrowserDialog.SelectedPath;
            }
            if (config.InputDirectory != null && config.OutDirectory != null)
            {
                btnSaveSetting.Enabled = true;
            }
            else
            {
                btnSaveSetting.Enabled = false;
            }
        }

        private void btnOutputDirectory_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                txtOutputDirectory.Text = folderBrowserDialog.SelectedPath;
                config.OutDirectory = folderBrowserDialog.SelectedPath;
            }
            if (config.InputDirectory != null && config.OutDirectory != null)
            {
                btnSaveSetting.Enabled = true;
            }
            else
            {
                btnSaveSetting.Enabled = false;
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            if (checkBoxStartWithWindows.Checked)
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                registryKey.SetValue("AutoManagerVideoFile", Application.ExecutablePath);
            }
            else
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                registryKey.DeleteValue("AutoManagerVideoFile", false);
            }
            ConfigUtil configUtil = new ConfigUtil();
            configUtil.saveConfig(config);
            FileWatched.initWatched(config);
            this.Close();
        }

        private void Setting_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Close();
            }
        }
    }
}
