using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoManagerVideoFile
{
    public partial class ChangeFileName : Form
    {
        private string tempPath;
        public ChangeFileName(string path)
        {
            InitializeComponent();
            tempPath = path;
            txtFileName.Text = Path.GetFileNameWithoutExtension(path);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FileWatched fileWatched = new FileWatched();
            string newFileName = Path.GetFileNameWithoutExtension(txtFileName.Text) +
                "_" + fileWatched.generateRandomString() + Path.GetExtension(tempPath);
            string newPath = Path.Combine(Path.GetDirectoryName(tempPath), newFileName);
            try
            {
                File.Move(tempPath, newPath);
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi! File chưa được đổi tên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }
    }
}
