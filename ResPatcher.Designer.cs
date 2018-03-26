namespace WMMT5_Resolution_Patcher
{
    partial class ResPatcher
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
            this.buttonApply = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.comboBoxResolution = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(215, 13);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 1;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "wmn5r.exe";
            this.openFileDialog1.Filter = "WMMT5.exe|wmn5r.exe";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.Title = "Please choose your wmn5r.exe";
            // 
            // comboBoxResolution
            // 
            this.comboBoxResolution.FormattingEnabled = true;
            this.comboBoxResolution.Items.AddRange(new object[] {
            "600x480",
            "640x360",
            "640x480",
            "640x512",
            "768x432",
            "800x600",
            "896x504",
            "960x720",
            "1024x576",
            "1024x768",
            "1152x648",
            "1152x864",
            "1280x720",
            "1280x960",
            "1280x1024",
            "1440x1080",
            "1600x900",
            "1600x1200",
            "1920x1080",
            "1920x1440",
            "2560x1080",
            "2560x1440",
            "2560x1920",
            "3440x1440",
            "3840x2160",
            "5120x2160",
            "5120x2880",
            "6880x2880",
            "7680x4320"});
            this.comboBoxResolution.Location = new System.Drawing.Point(12, 15);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(176, 21);
            this.comboBoxResolution.TabIndex = 2;
            // 
            // ResPatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 51);
            this.Controls.Add(this.comboBoxResolution);
            this.Controls.Add(this.buttonApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ResPatcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WMMT5 Resolution Patcher";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboBoxResolution;
    }
}

