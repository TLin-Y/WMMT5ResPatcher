using System;
using System.IO;
using System.Windows.Forms;

namespace WMMT5_Resolution_Patcher
{
    public partial class ResPatcher : Form
    {
        public ResPatcher()
        {
            InitializeComponent();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                Environment.Exit(1);
            }
            comboBoxResolution.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Int64 fileSizeInBytes = new FileInfo(openFileDialog1.FileName).Length;
            Int64 originalFileSize = 27366912;

            if (fileSizeInBytes != originalFileSize)
            {
                MessageBox.Show("Invalid exe or you don't have Update 5 installed. Please install Update 5 to use this patcher.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }       
            
            try
            {
                string dir = Path.GetDirectoryName(openFileDialog1.FileName);
                Directory.SetCurrentDirectory(dir);
                File.Copy(openFileDialog1.FileName, "wmn5r.bak", true);
                byte[] zeroarray = new byte[44] {00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00 };
                using (var patch = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    //Special thanks for offsets and values to Jackfuste from WSGF.org
                    
                    patch.Position = 0x7703EE;
                    patch.WriteByte(0xE9);
                    patch.WriteByte(0x59);
                    patch.WriteByte(0x13);
                    patch.WriteByte(0x51);
                    patch.WriteByte(0x00);
                    patch.WriteByte(0x90);
                    
                    patch.Position = 0x772C63;
                    patch.WriteByte(0xE9);
                    patch.WriteByte(0xFC);
                    patch.WriteByte(0xEA);
                    patch.WriteByte(0x50);
                    patch.WriteByte(0x00);
                    
                    patch.Position = 0xC8174C;
                    patch.WriteByte(0xC7);
                    patch.WriteByte(0x45);
                    patch.WriteByte(0xA8);
                    patch.WriteByte(0x55);
                    patch.WriteByte(0x55);          
                    patch.WriteByte(0x35);
                    patch.WriteByte(0x3F);
                    patch.WriteByte(0xF3);
                    patch.WriteByte(0x44);
                    patch.WriteByte(0x0F);
                    patch.WriteByte(0x59);
                    patch.WriteByte(0x6D);
                    patch.WriteByte(0xA8);
                    patch.WriteByte(0xF3);
                    patch.WriteByte(0x44);
                    patch.WriteByte(0x0F);
                    patch.WriteByte(0x11);
                    patch.WriteByte(0x6D);
                    patch.WriteByte(0xA8);
                    patch.WriteByte(0xE9);
                    patch.WriteByte(0x90);
                    patch.WriteByte(0xEC);
                    patch.WriteByte(0xAE);
                    patch.WriteByte(0xFF);
                    patch.WriteByte(0xC7);
                    patch.WriteByte(0x45);
                    patch.WriteByte(0x88);
                    patch.WriteByte(0x55);
                    patch.WriteByte(0x55);
                    patch.WriteByte(0x35);
                    patch.WriteByte(0x3F);
                    patch.WriteByte(0xF3);
                    patch.WriteByte(0x0F);
                    patch.WriteByte(0x59);
                    patch.WriteByte(0x45);
                    patch.WriteByte(0x88);
                    patch.WriteByte(0xF3);
                    patch.WriteByte(0x0F);
                    patch.WriteByte(0x11);
                    patch.WriteByte(0x45);
                    patch.WriteByte(0x88);
                    patch.WriteByte(0xE9);
                    patch.WriteByte(0xEE);
                    patch.WriteByte(0x14);
                    patch.WriteByte(0xAF);
                    patch.WriteByte(0xFF);

                    if (comboBoxResolution.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select a resolution.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (comboBoxResolution.SelectedIndex == 0) //600x480
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x02);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0xE0);
                        patch.WriteByte(0x01);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x02);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0xE0);
                        patch.WriteByte(0x01);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0xA0);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x9F);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x40);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x40);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x4B);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xA7);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 1) //640x360
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x02);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x68);
                        patch.WriteByte(0x01);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x02);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x68);
                        patch.WriteByte(0x01);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x08);
                        patch.WriteByte(0x40);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x08);
                        patch.WriteByte(0x40);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);

                        patch.Position = 0xC8177A;
                        patch.Write(zeroarray, 0, 44);


                    }

                    if (comboBoxResolution.SelectedIndex == 2) //640x480
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x02);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0xE0);
                        patch.WriteByte(0x01);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x02);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0xE0);
                        patch.WriteByte(0x01);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0xAB);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x9F);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x08);
                        patch.WriteByte(0x40);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x08);
                        patch.WriteByte(0x40);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x4B);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xA7);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 3) //640x512
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x02);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x02);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x02);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x02);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0xA0);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x9F);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x08);
                        patch.WriteByte(0x40);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x08);
                        patch.WriteByte(0x40);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x4B);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xA7);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 4) //768x432
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x03);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0x01);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x03);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0x01);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0xAB);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0xE2);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0xAB);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0xE2);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);

                        patch.Position = 0xC8177A;
                        patch.Write(zeroarray, 0, 44);
                    }

                    if (comboBoxResolution.SelectedIndex == 5) //800x600
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x20);
                        patch.WriteByte(0x03);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x02);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x20);
                        patch.WriteByte(0x03);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x02);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0xAB);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x9F);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x99);
                        patch.WriteByte(0x99);
                        patch.WriteByte(0xD9);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x99);
                        patch.WriteByte(0x99);
                        patch.WriteByte(0xD9);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x4B);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xA7);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 6) //896x504
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x03);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0xF8);
                        patch.WriteByte(0x01);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x03);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0xF8);
                        patch.WriteByte(0x01);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x25);
                        patch.WriteByte(0x49);
                        patch.WriteByte(0xC2);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0xAB);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0xC2);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);

                        patch.Position = 0xC8177A;
                        patch.Write(zeroarray, 0, 44);
                    }

                    if (comboBoxResolution.SelectedIndex == 7) //960x720
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0xC0);
                        patch.WriteByte(0x03);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0xD0);
                        patch.WriteByte(0x02);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0xC0);
                        patch.WriteByte(0x03);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0xD0);
                        patch.WriteByte(0x02);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0xAB);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x9F);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x55);
                        patch.WriteByte(0xB5);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x55);
                        patch.WriteByte(0xB5);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x4B);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xA7);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 8) //1024x576
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x04);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x40);
                        patch.WriteByte(0x02);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x04);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x40);
                        patch.WriteByte(0x02);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);

                        patch.Position = 0xC8177A;
                        patch.Write(zeroarray, 0, 44);
                    }

                    if (comboBoxResolution.SelectedIndex == 9) //1024x768
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x04);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x03);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x04);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x03);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0xAB);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x9F);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xA9);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xA9);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x4B);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xA7);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 10) //1152x648
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x04);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x88);
                        patch.WriteByte(0x02);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x04);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x88);
                        patch.WriteByte(0x02);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x72);
                        patch.WriteByte(0x1C);
                        patch.WriteByte(0x97);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x72);
                        patch.WriteByte(0x1C);
                        patch.WriteByte(0x97);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);

                        patch.Position = 0xC8177A;
                        patch.Write(zeroarray, 0, 44);
                    }

                    if (comboBoxResolution.SelectedIndex == 11) //1152x864
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x04);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x60);
                        patch.WriteByte(0x03);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x04);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x60);
                        patch.WriteByte(0x03);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0xAB);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x9F);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x71);
                        patch.WriteByte(0x1C);
                        patch.WriteByte(0x97);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x71);
                        patch.WriteByte(0x1C);
                        patch.WriteByte(0x97);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x4B);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xA7);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 12) //1280x720
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0xD0);
                        patch.WriteByte(0x02);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0xD0);
                        patch.WriteByte(0x02);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x88);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x88);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);

                        patch.Position = 0xC8177A;
                        patch.Write(zeroarray, 0, 44);
                    }

                    if (comboBoxResolution.SelectedIndex == 13) //1280x960
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0xC0);
                        patch.WriteByte(0x03);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0xC0);
                        patch.WriteByte(0x03);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0xAB);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x9F);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x88);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x88);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x4B);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xA7);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 14) //1280x1024
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x04);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x04);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0xA0);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x9F);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0xCD);
                        patch.WriteByte(0xCC);
                        patch.WriteByte(0x8C);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0xCD);
                        patch.WriteByte(0xCC);
                        patch.WriteByte(0x8C);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x4B);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xA7);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 15) //1440x1080
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0xA0);
                        patch.WriteByte(0x05);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x38);
                        patch.WriteByte(0x04);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0xA0);
                        patch.WriteByte(0x05);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x38);
                        patch.WriteByte(0x04);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0xAB);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x9F);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x1C);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x71);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x1C);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x71);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x4B);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xA7);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 16) //1600x900
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x40);
                        patch.WriteByte(0x06);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x84);
                        patch.WriteByte(0x03);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x40);
                        patch.WriteByte(0x06);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x84);
                        patch.WriteByte(0x03);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x9A);
                        patch.WriteByte(0x99);
                        patch.WriteByte(0x59);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x9A);
                        patch.WriteByte(0x99);
                        patch.WriteByte(0x59);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);

                        patch.Position = 0xC8177A;
                        patch.Write(zeroarray, 0, 44);
                    }

                    if (comboBoxResolution.SelectedIndex == 17) //1600x1200
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x40);
                        patch.WriteByte(0x06);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0x04);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x40);
                        patch.WriteByte(0x06);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0x04);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0xAB);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x9F);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x99);
                        patch.WriteByte(0x99);
                        patch.WriteByte(0x59);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x99);
                        patch.WriteByte(0x99);
                        patch.WriteByte(0x59);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x4B);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xA7);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 18) //1920x1080
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x07);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x38);
                        patch.WriteByte(0x04);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x07);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x38);
                        patch.WriteByte(0x04);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x35);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x35);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);

                        patch.Position = 0xC8177A;
                        patch.Write(zeroarray, 0, 44);
                    }

                    if (comboBoxResolution.SelectedIndex == 19) //1920x1440
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x07);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0xA0);
                        patch.WriteByte(0x05);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x07);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0xA0);
                        patch.WriteByte(0x05);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0xAB);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x9F);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x35);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x35);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x4B);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xA7);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 20) //2560x1080
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x0A);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x38);
                        patch.WriteByte(0x04);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x0A);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x38);
                        patch.WriteByte(0x04);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x26);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x17);
                        patch.WriteByte(0x40);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xC8);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x6F);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x61);
                        patch.WriteByte(0x0B);
                        patch.WriteByte(0x36);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x61);
                        patch.WriteByte(0x0B);
                        patch.WriteByte(0x36);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x66);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x22);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x66);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x7B);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 21) //2560x1440
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x0A);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0xA0);
                        patch.WriteByte(0x05);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x0A);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0xA0);
                        patch.WriteByte(0x05);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x08);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x08);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);

                        patch.Position = 0xC8177A;
                        patch.Write(zeroarray, 0, 44);
                    }

                    if (comboBoxResolution.SelectedIndex == 22) //2560x1920
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x0A);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x07);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x0A);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x80);
                        patch.WriteByte(0x07);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0xAB);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0xAA);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x9F);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x08);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x08);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x4B);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x05);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xA7);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 23) //3440x1440
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x70);
                        patch.WriteByte(0x0D);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0xA0);
                        patch.WriteByte(0x05);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x70);
                        patch.WriteByte(0x0D);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0xA0);
                        patch.WriteByte(0x05);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x18);
                        patch.WriteByte(0x40);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xC8);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x6F);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x49);
                        patch.WriteByte(0x86);
                        patch.WriteByte(0x08);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x49);
                        patch.WriteByte(0x86);
                        patch.WriteByte(0x08);
                        patch.WriteByte(0x3F);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x66);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x22);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x66);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x7B);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 24) //3840x2160
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x0F);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x70);
                        patch.WriteByte(0x08);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x0F);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x70);
                        patch.WriteByte(0x08);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x55);
                        patch.WriteByte(0xB5);
                        patch.WriteByte(0x3E);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x55);
                        patch.WriteByte(0xB5);
                        patch.WriteByte(0x3E);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);

                        patch.Position = 0xC8177A;
                        patch.Write(zeroarray, 0, 44);
                    }

                    if (comboBoxResolution.SelectedIndex == 25) //5120x2160
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x14);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x70);
                        patch.WriteByte(0x08);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x14);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x70);
                        patch.WriteByte(0x08);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x26);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x17);
                        patch.WriteByte(0x40);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xC8);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x6F);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x62);
                        patch.WriteByte(0x08);
                        patch.WriteByte(0xB6);
                        patch.WriteByte(0x3E);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x62);
                        patch.WriteByte(0x08);
                        patch.WriteByte(0xB6);
                        patch.WriteByte(0x3E);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x66);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x22);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x66);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x7B);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);

                    }

                    if (comboBoxResolution.SelectedIndex == 26) //5120x2880
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x14);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x40);
                        patch.WriteByte(0x0B);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x14);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x40);
                        patch.WriteByte(0x0B);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x88);
                        patch.WriteByte(0x3E);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x88);
                        patch.WriteByte(0x3E);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);

                        patch.Position = 0xC8177A;
                        patch.Write(zeroarray, 0, 44);
                    }

                    if (comboBoxResolution.SelectedIndex == 27) //6880x2880
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0xE0);
                        patch.WriteByte(0x1A);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0x40);
                        patch.WriteByte(0x0B);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0xE0);
                        patch.WriteByte(0x1A);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0x40);
                        patch.WriteByte(0x0B);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x18);
                        patch.WriteByte(0x40);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0xC8);
                        patch.WriteByte(0x13);
                        patch.WriteByte(0x51);
                        patch.WriteByte(0x00);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x6F);
                        patch.WriteByte(0xEB);
                        patch.WriteByte(0x50);
                        patch.WriteByte(0x00);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x49);
                        patch.WriteByte(0x86);
                        patch.WriteByte(0x88);
                        patch.WriteByte(0x3E);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x49);
                        patch.WriteByte(0x86);
                        patch.WriteByte(0x88);
                        patch.WriteByte(0x3E);

                        patch.Position = 0xC8177A;
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x66);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x22);
                        patch.WriteByte(0xEC);
                        patch.WriteByte(0xAE);
                        patch.WriteByte(0xFF);
                        patch.WriteByte(0xC7);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x66);
                        patch.WriteByte(0x43);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x58);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);
                        patch.WriteByte(0xE9);
                        patch.WriteByte(0x7B);
                        patch.WriteByte(0x14);
                        patch.WriteByte(0xAF);
                        patch.WriteByte(0xFF);
                    }

                    if (comboBoxResolution.SelectedIndex == 28) //7680x4320
                    {
                        patch.Position = 0xB8622;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x1E);
                        patch.Position = 0xB862C;
                        patch.WriteByte(0xE0);
                        patch.WriteByte(0x10);

                        patch.Position = 0xB8754;
                        patch.WriteByte(0x00);
                        patch.WriteByte(0x1E);
                        patch.Position = 0xB875B;
                        patch.WriteByte(0xE0);
                        patch.WriteByte(0x10);

                        patch.Position = 0xC8174F;
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x35);
                        patch.WriteByte(0x3E);

                        patch.Position = 0xC81767;
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x55);
                        patch.WriteByte(0x35);
                        patch.WriteByte(0x3E);

                        patch.Position = 0xCE389;
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);

                        patch.Position = 0x7703AD;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0xB0);

                        patch.Position = 0x7703D6;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0xB4);

                        patch.Position = 0x772C1C;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x45);
                        patch.WriteByte(0x90);

                        patch.Position = 0x772C48;
                        patch.WriteByte(0xF3);
                        patch.WriteByte(0x0F);
                        patch.WriteByte(0x11);
                        patch.WriteByte(0x4D);
                        patch.WriteByte(0x94);

                        patch.Position = 0xC8177A;
                        patch.Write(zeroarray, 0, 44);
                    }
                
                }
                MessageBox.Show("Patching done", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Can't read or write wmn5r.exe, close the game and run the patcher as admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}