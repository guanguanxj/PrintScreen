using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace GetScreen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Image myImg = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Graphics g = Graphics.FromImage(myImg);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            myImg.Save("Capture.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("当前屏幕已经保存为capture.jpg文件！");
        }
        MouseHook mh;
        Point p;
        int clicks = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            try
            {
                mh = new MouseHook();
                mh.MouseClickEvent += mh_MouseClickEvent;
                while (clicks == 0)
                {
                    mh.Start();
                    return;
                }
            }
            catch (Exception ex)
            {
                mh.Dispose();
            }
            
        }

        private void mh_MouseClickEvent(object sender, MouseEventArgs e)
        {
            p = new Point();
            p.X = e.X;
            p.Y = e.Y;
            clicks = e.Clicks;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
