using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace AutoManagerVideoFile
{
    class ConfigUtil
    {
        private readonly string fileConfigName = "config.dat";
        public void saveConfig(Config config)
        {
            FileStream fs = new FileStream(fileConfigName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, config);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Failed to create new file!\nReason: " + exception.Message, "Take an error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                fs.Close();
            }
        }

        public Config getConfig()
        {
            if (!File.Exists(fileConfigName))
            {
                return null;
            }

            FileStream serializationStream = new FileStream(fileConfigName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Config config = (Config)formatter.Deserialize(serializationStream);
                return config;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Failed to create new file!\nReason: " + exception.Message, "Take an error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            finally
            {
                serializationStream.Close();
            }
        }
    }
}
