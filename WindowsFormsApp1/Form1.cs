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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private MP3CLASS mp3player = new MP3CLASS();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Mp3 Files|*.mp3";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    /*foreach(string f in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(f);
                        ListViewItem item = new ListViewItem(ID.ToString());
                        item.SubItems.Add(fi.Name,);
                        listView.Items.Add(item);
                        ID++;
                    }*/
                    mp3player.open(ofd.FileName);
                    FileInfo fi = new FileInfo(ofd.FileName);
                    nameLabel.Text = Path.GetFileNameWithoutExtension(fi.Name);
                    mp3player.play();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mp3player.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mp3player.stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // How to move a form without having a Titlebar in C#
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
