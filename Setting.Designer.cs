namespace AutoManagerVideoFile
{
    partial class Setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInputDirectory = new System.Windows.Forms.TextBox();
            this.txtOutputDirectory = new System.Windows.Forms.TextBox();
            this.btnInputDirectory = new System.Windows.Forms.Button();
            this.btnOutputDirectory = new System.Windows.Forms.Button();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBoxStartWithWindows = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn thư mục đầu vào";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chọn thư mục đầu ra";
            // 
            // txtInputDirectory
            // 
            this.txtInputDirectory.Location = new System.Drawing.Point(134, 24);
            this.txtInputDirectory.Name = "txtInputDirectory";
            this.txtInputDirectory.ReadOnly = true;
            this.txtInputDirectory.Size = new System.Drawing.Size(329, 20);
            this.txtInputDirectory.TabIndex = 2;
            // 
            // txtOutputDirectory
            // 
            this.txtOutputDirectory.Location = new System.Drawing.Point(134, 64);
            this.txtOutputDirectory.Name = "txtOutputDirectory";
            this.txtOutputDirectory.ReadOnly = true;
            this.txtOutputDirectory.Size = new System.Drawing.Size(329, 20);
            this.txtOutputDirectory.TabIndex = 3;
            // 
            // btnInputDirectory
            // 
            this.btnInputDirectory.Location = new System.Drawing.Point(469, 21);
            this.btnInputDirectory.Name = "btnInputDirectory";
            this.btnInputDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnInputDirectory.TabIndex = 4;
            this.btnInputDirectory.Text = "Chọn";
            this.btnInputDirectory.UseVisualStyleBackColor = true;
            this.btnInputDirectory.Click += new System.EventHandler(this.btnInputDirectory_Click);
            // 
            // btnOutputDirectory
            // 
            this.btnOutputDirectory.Location = new System.Drawing.Point(469, 61);
            this.btnOutputDirectory.Name = "btnOutputDirectory";
            this.btnOutputDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnOutputDirectory.TabIndex = 5;
            this.btnOutputDirectory.Text = "Chọn";
            this.btnOutputDirectory.UseVisualStyleBackColor = true;
            this.btnOutputDirectory.Click += new System.EventHandler(this.btnOutputDirectory_Click);
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Enabled = false;
            this.btnSaveSetting.Location = new System.Drawing.Point(12, 130);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(532, 23);
            this.btnSaveSetting.TabIndex = 6;
            this.btnSaveSetting.Text = "Lưu cài đặt";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // checkBoxStartWithWindows
            // 
            this.checkBoxStartWithWindows.AutoSize = true;
            this.checkBoxStartWithWindows.Location = new System.Drawing.Point(15, 98);
            this.checkBoxStartWithWindows.Name = "checkBoxStartWithWindows";
            this.checkBoxStartWithWindows.Size = new System.Drawing.Size(149, 17);
            this.checkBoxStartWithWindows.TabIndex = 7;
            this.checkBoxStartWithWindows.Text = "Khởi động cùng Windows";
            this.checkBoxStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 165);
            this.Controls.Add(this.checkBoxStartWithWindows);
            this.Controls.Add(this.btnSaveSetting);
            this.Controls.Add(this.btnOutputDirectory);
            this.Controls.Add(this.btnInputDirectory);
            this.Controls.Add(this.txtOutputDirectory);
            this.Controls.Add(this.txtInputDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cài đặt ";
            this.Resize += new System.EventHandler(this.Setting_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInputDirectory;
        private System.Windows.Forms.TextBox txtOutputDirectory;
        private System.Windows.Forms.Button btnInputDirectory;
        private System.Windows.Forms.Button btnOutputDirectory;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox checkBoxStartWithWindows;
    }
}