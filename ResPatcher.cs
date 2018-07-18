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

            short xint = Convert.ToInt16(Xres.Text);
            short yint = Convert.ToInt16(Yres.Text);

            float aspect = (float)xint / yint;

            string aspectstring = Convert.ToString(aspect);

            if (aspectstring.Equals("1,6"))
            {
                MessageBox.Show("16:10 is not supported yet, sorry.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!aspectstring.Equals("1,777778") && !aspectstring.Equals("2,37037") && !aspectstring.Equals("1,333333") && !aspectstring.Equals("1,25"))
            {
                MessageBox.Show("Invalid resolution.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string dir = Path.GetDirectoryName(openFileDialog1.FileName);
                Directory.SetCurrentDirectory(dir);
                File.Copy(openFileDialog1.FileName, "wmn5r.bak", true);
                byte[] zeroarray = new byte[44] { 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00 };
                using (var patch = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    //Special thanks for offsets and values to Jackfuste from WSGF.org
                    byte[] bytearray1 = new byte[6] { 0xE9, 0x59, 0x13, 0x51, 0x00, 0x90 };
                    patch.Position = 0x7703EE;
                    patch.Write(bytearray1, 0, 6);

                    byte[] bytearray2 = new byte[5] { 0xE9, 0xFC, 0xEA, 0x50, 0x00 };
                    patch.Position = 0x772C63;
                    patch.Write(bytearray2, 0, 5);

                    byte[] bytearray3 = new byte[46] { 0xC7, 0x45, 0xA8, 0x55, 0x55, 0x35, 0x3F, 0xF3, 0x44, 0x0F, 0x59, 0x6D, 0xA8, 0xF3, 0x44, 0x0F, 0x11, 0x6D, 0xA8, 0xE9, 0x90, 0xEC, 0xAE, 0xFF, 0xC7, 0x45, 0x88, 0x55, 0x55, 0x35, 0x3F, 0xF3, 0x0F, 0x59, 0x45, 0x88, 0xF3, 0x0F, 0x11, 0x45, 0x88, 0xE9, 0xEE, 0x14, 0xAF, 0xFF };
                    patch.Position = 0xC8174C;
                    patch.Write(bytearray3, 0, 46);

                    //short/int16 -> byte[]           
                    byte[] x = BitConverter.GetBytes(xint);
                    byte[] y = BitConverter.GetBytes(yint);

                    patch.Position = 0xB8622;
                    patch.Write(x, 0, 2);
                    patch.Position = 0xB862C;
                    patch.Write(y, 0, 2);

                    patch.Position = 0xB8754;
                    patch.Write(x, 0, 2);
                    patch.Position = 0xB875B;
                    patch.Write(y, 0, 2);

                    if (aspectstring.Equals("1,777778")) //16:9
                    {
                        float extra16_9 = (float)765 / yint;
                        byte[] extra16_9array = BitConverter.GetBytes(extra16_9);

                        byte[] array16_9 = new byte[24] { 0x39, 0x8E, 0xE3, 0x3F, 0xF3, 0x0F, 0x11, 0x45, 0xB0, 0xF3, 0x0F, 0x11, 0x4D, 0xB4, 0xF3, 0x0F, 0x11, 0x45, 0x90, 0xF3, 0x0F, 0x11, 0x4D, 0x94 };

                        patch.Position = 0xCE389;
                        patch.Write(array16_9, 0, 4);

                        patch.Position = 0xC8174F;
                        patch.Write(extra16_9array, 0, 4);

                        patch.Position = 0xC81767;
                        patch.Write(extra16_9array, 0, 4);

                        patch.Position = 0x7703AD;
                        patch.Write(array16_9, 4, 5);

                        patch.Position = 0x7703D6;
                        patch.Write(array16_9, 9, 5);

                        patch.Position = 0x772C1C;
                        patch.Write(array16_9, 14, 5);

                        patch.Position = 0x772C48;
                        patch.Write(array16_9, 19, 5);

                        patch.Position = 0xC8177A;
                        patch.Write(zeroarray, 0, 44);
                    }

                    if (aspectstring.Equals("1,333333")) //4:3
                    {
                        byte[] main4_3 = new byte[24] { 0xAB, 0xAA, 0xAA, 0x3F, 0xF3, 0x0F, 0x11, 0x45, 0xB0, 0xE9, 0x9F, 0x13, 0x51, 0x00, 0xF3, 0x0F, 0x11, 0x45, 0x90, 0xE9, 0x43, 0xEB, 0x50, 0x00 };

                        patch.Position = 0xCE389;
                        patch.Write(main4_3, 0, 4);

                        float extra4_3 = (float)1020 / yint;
                        byte[] extra4_3array = BitConverter.GetBytes(extra4_3);

                        patch.Position = 0xC8174F;
                        patch.Write(extra4_3array, 0, 4);
                        patch.Position = 0xC81767;
                        patch.Write(extra4_3array, 0, 4);

                        patch.Position = 0x7703AD;
                        patch.Write(main4_3, 4, 5);

                        patch.Position = 0x7703D6;
                        patch.Write(main4_3, 9, 5);

                        patch.Position = 0x772C1C;
                        patch.Write(main4_3, 14, 5);

                        patch.Position = 0x772C48;
                        patch.Write(main4_3, 19, 5);

                        patch.Position = 0xC8177A;
                        byte[] misc4_3 = new byte[44] { 0xC7, 0x45, 0xB4, 0x00, 0x00, 0x05, 0x43, 0xF3, 0x0F, 0x58, 0x4D, 0xB4, 0xF3, 0x0F, 0x11, 0x4D, 0xB4, 0xE9, 0x4B, 0xEC, 0xAE, 0xFF, 0xC7, 0x45, 0x94, 0x00, 0x00, 0x05, 0x43, 0xF3, 0x0F, 0x58, 0x4D, 0x94, 0xF3, 0x0F, 0x11, 0x4D, 0x94, 0xE9, 0xA7, 0x14, 0xAF, 0xFF };
                        patch.Write(misc4_3, 0, 44);
                    }

                    if (aspectstring.Equals("1,25")) //5:4
                    {
                        byte[] main5_4 = new byte[24] { 0x00, 0x00, 0xA0, 0x3F, 0xF3, 0x0F, 0x11, 0x45, 0xB0, 0xE9, 0x9F, 0x13, 0x51, 0x00, 0xF3, 0x0F, 0x11, 0x45, 0x90, 0xE9, 0x43, 0xEB, 0x50, 0x00 };

                        patch.Position = 0xCE389;
                        patch.Write(main5_4, 0, 4);

                        float extra5_4 = (float)1088 / yint;
                        byte[] extra5_4array = BitConverter.GetBytes(extra5_4);

                        patch.Position = 0xC8174F;
                        patch.Write(extra5_4array, 0, 4);
                        patch.Position = 0xC81767;
                        patch.Write(extra5_4array, 0, 4);

                        patch.Position = 0x7703AD;
                        patch.Write(main5_4, 4, 5);

                        patch.Position = 0x7703D6;
                        patch.Write(main5_4, 9, 5);

                        patch.Position = 0x772C1C;
                        patch.Write(main5_4, 14, 5);

                        patch.Position = 0x772C48;
                        patch.Write(main5_4, 19, 5);

                        patch.Position = 0xC8177A;
                        byte[] misc4_3 = new byte[44] { 0xC7, 0x45, 0xB4, 0x00, 0x00, 0x05, 0x43, 0xF3, 0x0F, 0x58, 0x4D, 0xB4, 0xF3, 0x0F, 0x11, 0x4D, 0xB4, 0xE9, 0x4B, 0xEC, 0xAE, 0xFF, 0xC7, 0x45, 0x94, 0x00, 0x00, 0x05, 0x43, 0xF3, 0x0F, 0x58, 0x4D, 0x94, 0xF3, 0x0F, 0x11, 0x4D, 0x94, 0xE9, 0xA7, 0x14, 0xAF, 0xFF };
                        patch.Write(misc4_3, 0, 44);
                    }

                    if (aspectstring.Equals("2,37037")) //21:9
                    {
                        float extra21_9 = (float)767.999988 / yint;
                        byte[] extra21_9array = BitConverter.GetBytes(extra21_9);

                        byte[] array21_9 = new byte[14] { 0x26, 0xB4, 0x17, 0x40, 0xE9, 0xC8, 0x13, 0x51, 0x00, 0xE9, 0x6F, 0xEB, 0x50, 0x00 };

                        patch.Position = 0xCE389;
                        patch.Write(array21_9, 0, 4);

                        patch.Position = 0xC8174F;
                        patch.Write(extra21_9array, 0, 4);

                        patch.Position = 0xC81767;
                        patch.Write(extra21_9array, 0, 4);

                        patch.Position = 0x7703AD;
                        patch.Write(array21_9, 4, 5);

                        patch.Position = 0x772C1C;
                        patch.Write(array21_9, 9, 5);

                        patch.Position = 0xC8177A;
                        byte[] misc21_9 = new byte[44] { 0xC7, 0x45, 0xB0, 0x00, 0x00, 0x66, 0x43, 0xF3, 0x0F, 0x58, 0x45, 0xB0, 0xF3, 0x0F, 0x11, 0x45, 0xB0, 0xE9, 0x22, 0xEC, 0xAE, 0xFF, 0xC7, 0x45, 0x90, 0x00, 0x00, 0x66, 0x43, 0xF3, 0x0F, 0x58, 0x45, 0x90, 0xF3, 0x0F, 0x11, 0x45, 0x90, 0xE9, 0x7B, 0x14, 0xAF, 0xFF };
                    }

                    if (aspectstring.Equals("1,6")) //16:10
                    {
                        //TODO
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