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
            this.Xres = new System.Windows.Forms.TextBox();
            this.Yres = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // Xres
            // 
            this.Xres.Location = new System.Drawing.Point(12, 15);
            this.Xres.Name = "Xres";
            this.Xres.Size = new System.Drawing.Size(77, 20);
            this.Xres.TabIndex = 2;
            // 
            // Yres
            // 
            this.Yres.Location = new System.Drawing.Point(113, 15);
            this.Yres.Name = "Yres";
            this.Yres.Size = new System.Drawing.Size(77, 20);
            this.Yres.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "x";
            // 
            // ResPatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 51);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Yres);
            this.Controls.Add(this.Xres);
            this.Controls.Add(this.buttonApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ResPatcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WMMT5 Resolution Patcher";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox Xres;
        private System.Windows.Forms.TextBox Yres;
        private System.Windows.Forms.Label label1;
    }
}

