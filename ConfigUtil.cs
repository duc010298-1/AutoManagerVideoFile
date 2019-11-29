using Microsoft.Win32;
using System.IO;

namespace AutoManagerVideoFile
{
    class ConfigUtil
    {
        public void saveConfig(Config config)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AutoManagerVideoFile");

            key.SetValue("InputDirectory", config.InputDirectory);
            key.SetValue("OutputDirectory", config.OutDirectory);
            key.Close();
        }

        public Config getConfig()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AutoManagerVideoFile");

            if (key != null)
            {
                Config config = new Config();
                config.InputDirectory = (string)key.GetValue("InputDirectory");
                config.OutDirectory = (string)key.GetValue("OutputDirectory");
                key.Close();
                if (!Directory.Exists(config.InputDirectory) || !Directory.Exists(config.OutDirectory))
                {
                    return null;
                }
                return config;
            }
            else
            {
                return null;
            }
        }
    }
}
