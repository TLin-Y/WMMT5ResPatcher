using System;
using System.IO;
using System.Windows.Forms;

namespace WMMT5_Resolution_Patcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = Path.GetDirectoryName(openFileDialog1.FileName);
                Directory.SetCurrentDirectory(dir);
                File.Copy(openFileDialog1.FileName, "wmn5r.bak", true);

                using (var patch = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    //Special thanks for offsets to Jackfuste from WSGF.org

                    //unknown 1
                    patch.Position = 0x7703EE;
                    patch.WriteByte(0xE9);
                    patch.WriteByte(0x59);
                    patch.WriteByte(0x13);
                    patch.WriteByte(0x51);
                    patch.WriteByte(0x00);
                    patch.WriteByte(0x90);

                    //unknown 2
                    patch.Position = 0x772C63;
                    patch.WriteByte(0xE9);
                    patch.WriteByte(0xFC);
                    patch.WriteByte(0xEA);
                    patch.WriteByte(0x50);
                    patch.WriteByte(0x00);

                    //unknown 3
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

                    if (listBox1.SelectedIndex == 0)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);
                    }

                    if (listBox1.SelectedIndex == 1)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);
                    }

                    if (listBox1.SelectedIndex == 2)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);
                    }

                    if (listBox1.SelectedIndex == 3)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);
                    }

                    if (listBox1.SelectedIndex == 4)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);
                    }

                    if (listBox1.SelectedIndex == 5)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);
                    }

                    if (listBox1.SelectedIndex == 6)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);
                    }

                    if (listBox1.SelectedIndex == 7)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
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
                    }

                    if (listBox1.SelectedIndex == 8)
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

                        patch.Position = 0xCE389; //aspect ratio
                        patch.WriteByte(0x26);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x17);
                        patch.WriteByte(0x40);

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
                    }

                    if (listBox1.SelectedIndex == 9)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);
                    }

                    if (listBox1.SelectedIndex == 10)
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

                        patch.Position = 0xCE389; //aspect ratio
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x18);
                        patch.WriteByte(0x40);

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
                    }

                    if (listBox1.SelectedIndex == 11)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);
                    }

                    if (listBox1.SelectedIndex == 12)
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

                        patch.Position = 0xCE389; //aspect ratio
                        patch.WriteByte(0x26);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x17);
                        patch.WriteByte(0x40);

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

                    }

                    if (listBox1.SelectedIndex == 13)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);
                    }

                    if (listBox1.SelectedIndex == 14)
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

                        patch.Position = 0xCE389; //aspect ratio
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x18);
                        patch.WriteByte(0x40);

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
                    }

                    if (listBox1.SelectedIndex == 15)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
                        patch.WriteByte(0x39);
                        patch.WriteByte(0x8E);
                        patch.WriteByte(0xE3);
                        patch.WriteByte(0x3F);
                    }

                    if (listBox1.SelectedIndex == 16)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
                        patch.WriteByte(0x26);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x17);
                        patch.WriteByte(0x40);
                    }

                    if (listBox1.SelectedIndex == 17)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
                        patch.WriteByte(0x26);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x17);
                        patch.WriteByte(0x40);
                    }

                    if (listBox1.SelectedIndex == 18)
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

                        patch.Position = 0xCE389; //aspect ratio 39 8E E3 3F
                        patch.WriteByte(0x26);
                        patch.WriteByte(0xB4);
                        patch.WriteByte(0x17);
                        patch.WriteByte(0x40);

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
