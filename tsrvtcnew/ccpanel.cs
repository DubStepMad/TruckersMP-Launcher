using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Linq;

namespace tsrvtcnew
{
    public partial class ccpanel : Form
    {
        private BackgroundWorker bw;
        public int a = 1;

        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int ccpanel_hotmey_ID = 1;
        public static bool setbusy = false;
        public string message = "";
        public string ccpath = "";
        public ccpanel()
        {
            InitializeComponent();

            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            RegisterHotKey(this.Handle, ccpanel_hotmey_ID, 4, (int)Keys.Y);
        }

        private void ccpanel_Load(object sender, EventArgs e)
        {
            var matches = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Euro Truck Simulator 2/profiles", "ccpoints.txt?", SearchOption.AllDirectories);
            var ccdir = matches.Take(1);
            foreach (var myscore in ccdir)
            {
                string myresult = myscore.ToString();
                ccpath = myresult;
            }

            Properties.Settings.Default.ccpanelcheck = true;
            Properties.Settings.Default.Save();


            string line;

            if (matches.Length == 0)
            {
                MessageBox.Show("Error, ccpoints.txt missing from profile!");
                return;
            }
            if (matches.Length == 1)
            {
                StreamReader file = new StreamReader(ccpath);
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("supervisor:"))
                    {
                        message = (line.Split(':')[1]);
                        txtbsuper.Text = message;
                    }
                    if (line.StartsWith("lead:"))
                    {
                        message = (line.Split(':')[1]);
                        txtblead.Text = message;
                    }
                    if (line.StartsWith("rear:"))
                    {
                        message = (line.Split(':')[1]);
                        txtbrear.Text = message;
                    }
                }
            }
            if (matches.Length < 1)
            {
                MessageBox.Show("You have more than 1 ccpoints.txt in the profiles folder. Only have 1!");
            }
        }

        private void ccpanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ccpanelcheck = false;
            Properties.Settings.Default.Save();
        }

        private void ccpanel_MouseDown(object sender,
        System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == ccpanel_hotmey_ID)
            {
                Clipboard.SetText(message);
                Thread.Sleep(1000);

                if (!bw.IsBusy && setbusy == false)
                {
                    Form1.goodsound();
                    this.bw.RunWorkerAsync();
                    this.bw.WorkerSupportsCancellation = true;
                }
                if (setbusy == true)
                {
                    setbusy = false;
                    this.bw.CancelAsync();
                    Form1.truckhorn();
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            setbusy = false;
            this.bw.CancelAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            for (int i = 0; i < 100; ++i)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    timer.ccpanel_action(); /*Keyboard input and custom wait delay*/
                }
            }
        }
        private void rb_welcome_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("welcomemessage:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_start_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("start:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_end_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("end:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point1_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point01:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point2_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point02:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point3_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point03:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point4_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point04:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point5_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point05:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point6_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point06:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point7_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point07:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point8_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point08:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point9_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point09:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point10_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point10:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point11_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point11:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point12_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point12:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point13_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point13:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point14_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point14:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point15_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point15:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point16_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point16:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point17_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point17:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point18_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point2=18:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point19_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point19:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point20_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point20:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point21_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point21:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point22_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point22:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point23_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point23:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point24_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point24:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point25_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point25:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point26_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point26:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point27_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point27:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point28_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point28:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point29_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point29:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point30_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point30:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point31_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point31:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point32_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point32:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point33_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point33:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point34_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point34:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point35_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point35:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point36_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point36:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point37_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point37:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point38_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point38:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point39_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point39:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point40_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point40:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point41_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point41:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point42_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point42:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point43_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point43:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point44_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void rb_point45_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point45:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point46_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point46:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point47_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point47:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point48_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point48:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point49_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point49:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }
        private void rb_point50_CheckedChanged(object sender, EventArgs e)
        {

            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("point50:"))
                {
                    message = (line.Split(':')[1]);
                    txtb_message.Text = message;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            this.button1.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }
        void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.button1.BackgroundImage = ((Image)(Properties.Resources.crossbg));
        }
        private void btnmini_Leave(object sender, EventArgs e)
        {
            this.btnmini.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }
        void btnmini_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnmini.BackgroundImage = ((Image)(Properties.Resources.line_icon));
        }
    }
}
