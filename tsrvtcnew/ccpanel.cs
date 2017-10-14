using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Linq;
using System.Diagnostics;

namespace tsrvtcnew
{
    public partial class ccpanel : Form
    {
        private BackgroundWorker bw;
        public int a = 1;

        //DLL libraries used to manage hotkeys
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
            Properties.Settings.Default.ccpanelcheck = true;
            Properties.Settings.Default.Save();

            Filesearch();
        }

        private void Filesearch()
        {
            var matches = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Euro Truck Simulator 2/profiles", "ccpoints.txt", SearchOption.AllDirectories);
            var ccdir = matches.Take(1);
            foreach (var myscore in ccdir)
            {
                string myresult = myscore.ToString();
                ccpath = myresult;
            }
            if (matches.Length == 0)
            {
                string createpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Euro Truck Simulator 2/profiles";

                string filename = Path.Combine(createpath, "ccpoints.txt");
                if (!System.IO.File.Exists(filename))
                    System.IO.File.WriteAllText(filename, Properties.Resources.ccpoints);
                Filesearch();
            }
            else if (matches.Length == 1)
            {
                Loadtext();
            }
            else if (matches.Length > 1)
            {
                MessageBox.Show("You have more than 1 ccpoints.txt in the profiles folder. \n Remove one from your files folder in the ETS2 folder in Documents!");
                this.Close();
            }
        }

        private void Loadtext()
        {
            string line;

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
                    timer.ccpanel_action(); //Keyboard input and custom wait delay
                }
            }
        }

        //radio button passes tag which shortens this code by 49... can't believe I copied this 50 times and this is what it is now
        private void anyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            string lineStart = (string)radio.Tag;
            ReadLineAndDisplayText(lineStart);
        }
        private void ReadLineAndDisplayText(string lineStart)
        {
            string line;

            StreamReader file = new StreamReader(ccpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith(lineStart))
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
            this.button1.BackgroundImage = ((Image)(Properties.Resources.cross_hover));
        }
        private void btnmini_Leave(object sender, EventArgs e)
        {
            this.btnmini.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }
        void btnmini_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnmini.BackgroundImage = ((Image)(Properties.Resources.line_icon));
        }

        private void vtn_ccp_edit_Click(object sender, EventArgs e)
        {
            string path = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            if (path != "")
            {
                ccpath = path +  "\\Euro Truck Simulator 2\\profiles";
                Process.Start("explorer.exe", ccpath);
                this.Close();
            }
            if (path == "")
            {
                MessageBox.Show("Error locating documents folder, please run this program with admin perms!");
            }
        }
    }
}
