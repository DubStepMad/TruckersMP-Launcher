using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace tsrvtcnew
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            string fullPath = Path.Combine(exeDir, "custom gui");

            Properties.Settings.Default.datapath = fullPath;
            Properties.Settings.Default.Save();

            txtpath.Text = Properties.Settings.Default.launcherpath;
            txtdatapath.Text = Properties.Settings.Default.datapath;

            if (Properties.Settings.Default.tbchk == true)
            {
                cb_tb.Checked = true;
            }
            if (Properties.Settings.Default.tbchk == false)
            {
                cb_tb.Checked = false;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnsave_Click(object sender, EventArgs e)
        {
            if (txtdatapath.Text == "")
            {
                MessageBox.Show("Please select gui location before saving!");
                Form1.errorsound();
                return;
            }
            if (txtpath.Text == "")
            {
                MessageBox.Show("Please select launcher location before saving!");
                Form1.errorsound();
                return;
            }

            Properties.Settings.Default.launcherpath = txtpath.Text;
            Properties.Settings.Default.datapath = txtdatapath.Text;
            Properties.Settings.Default.Save();

            Form1.goodsound();
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog lfpath = new FolderBrowserDialog();
            if (lfpath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtpath.Text = lfpath.SelectedPath;
        }
        private void btnsave_Leave(object sender, EventArgs e)
        {
            this.btnsave.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }

        void btnsave_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnsave.BackgroundImage = ((Image)(Properties.Resources.hover_img));
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void settings_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnclose_Leave(object sender, EventArgs e)
        {
            this.btnclose.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }
        void btnclose_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnclose.BackgroundImage = ((Image)(Properties.Resources.crossbg));
        }

        private void cb_tb_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_tb.Checked == true)
            {
                Properties.Settings.Default.tbchk = true;
                Properties.Settings.Default.Save();
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.agreed == true)
            {
                Properties.Settings.Default.agreed = false;
                Properties.Settings.Default.Save();
            }
            if (cb_tb.Checked == true)
            {
                cb_tb.Checked = false;
                Properties.Settings.Default.tbchk = false;
                Properties.Settings.Default.Save();
            }

            Properties.Settings.Default.launcherpath = "";
            Properties.Settings.Default.message = "";
            Properties.Settings.Default.Save();

            MessageBox.Show("All settings have been set to their Default setting.");
        }
    }
}
