﻿using System;
using System.Windows.Forms;

namespace tsrvtcnew
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            this.button1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.leave_img));
        }

        void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.button1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.hover_img));
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Help_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnhelpvids_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/playlist?list=PL1QbbJCBdwOJ10bgBPLyPD7m8MA8lzB7V");
        }

        private void btn_bf_MouseMove(object sender, MouseEventArgs e)
        {
            this.btn_bf.ForeColor = System.Drawing.Color.FromArgb(255, 192, 128);
        }
        private void btn_bf_Leave(object sender, EventArgs e)
        {
            this.btn_bf.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
        }

        private void btnhelpvids_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnhelpvids.ForeColor = System.Drawing.Color.FromArgb(255, 192, 128);
        }
        private void btnhelpvids_Leave(object sender, EventArgs e)
        {
            this.btnhelpvids.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
        }

        private void btn_bf_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://goo.gl/forms/MCuur032uOhz77wM2");
        }
    }
}
