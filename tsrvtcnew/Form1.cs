using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Media;
using System.Threading;
using System.Reflection;

namespace tsrvtcnew
{
    public partial class Form1 : Form
    {
        private BackgroundWorker bw;

        public int a = 1;
        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public const int MYACTION_HOTKEY_ID = 1;

        public static int timeconvert;
        public static bool setbusy = false;
        public static string Check = "";
        public static bool calc_check;
        public bool filecheck = false;



        public Form1()
        {
            InitializeComponent();

            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            txtmessage.Text = Properties.Settings.Default.message;

            // Modifier keys codes: Alt = 1, Ctrl = 2, Shift = 4, Win = 8
            // Compute the addition of each combination of the keys you want to be pressed
            // ALT+CTRL = 1 + 2 = 3 , CTRL+SHIFT = 2 + 4 = 6...
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 2, (int)Keys.Y);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            if (Properties.Settings.Default.agreed == false)
            {
                tc tc = new tsrvtcnew.tc();
                tc.ShowDialog();
            }

            Properties.Settings.Default.ccpanelcheck = false;
            Properties.Settings.Default.Save();

            //Preparing for auto updates.
            string updaterFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string updaterDir = Path.GetDirectoryName(updaterFile);
            string fullPath = Path.Combine(updaterDir, "updater.exe");

            if (!File.Exists(Path.Combine(updaterDir, "updater.exe")))
            {
                MessageBox.Show("Program is corrupted, please re-install or repair!");
                errorsound();
                filecheck = false;
            }
            if (File.Exists(Path.Combine(updaterDir, "updater.exe")))
            {
                filecheck = true;
            }
            if (fullPath != null && filecheck == true)
            {
                Process.Start(@"updater");
            }
            else
            {
                Application.Exit();
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID && Properties.Settings.Default.ccpanelcheck == false)
            {
                Clipboard.SetText(txtmessage.Text);

                Thread.Sleep(1000);

                if (!bw.IsBusy && setbusy == false)
                {
                    goodsound();
                    this.bw.RunWorkerAsync();
                    this.bw.WorkerSupportsCancellation = true;
                }
                if (setbusy == true)
                {
                    setbusy = false;
                    this.bw.CancelAsync();
                    truckhorn();
                    return;
                }
                if (timeconvert <= 0 )
                {
                    setbusy = false;
                    this.bw.CancelAsync();
                    truckhorn();
                    MessageBox.Show("Please enter a number into the timer field above 0!");
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
                    timer.calculate(); //Keyboard input and custom wait delay
                }
            }
        }

        private void Form1_MouseDown(object sender,
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

        public bool start_message { get; private set; }

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void btnltmp_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.replacegui == true)
            {
                gui_replace();
            }

            RegistryCheck.Read();
        }

        public static void gui_replace()
        {
            string SourcePath = (Properties.Settings.Default.datapath);
            string DesPath = ("C:/ProgramData/TruckersMP");

            //gets application directory
            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            string finalPath = Path.Combine(exeDir, "custom gui");

            if (finalPath == null)
            {
                MessageBox.Show("Application must be ran as an Administrator!");
                errorsound();
                return;
            }

            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(DesPath + dirPath.Remove(0, SourcePath.Length));

            foreach (String newPath in Directory.GetFiles(SourcePath, "*.*",
                    SearchOption.AllDirectories))
                File.Copy(newPath, DesPath + newPath.Remove(0, SourcePath.Length), true);
            goodsound();
            return;
        }

        //small button functions
        //button hover overs and resets
        private void btnhelp_Click(object sender, EventArgs e)
        {
            Help hp = new tsrvtcnew.Help();
            hp.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            settings ss = new tsrvtcnew.settings();
            ss.ShowDialog();
        }
        private void btnfb_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.facebook.com/TSRVTC/");
        }
        private void btndiscord_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/VXzCurC");
        }
        private void btn_pp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.me/ConnorNee97");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Leave(object sender, EventArgs e)
        {
            this.button1.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }
        void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.button1.BackgroundImage = ((Image)(Properties.Resources.cross_hover));
        }
        private void btnmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnmini_Leave(object sender, EventArgs e)
        {
            this.btnmini.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }
        void btnmini_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnmini.BackgroundImage = ((Image)(Properties.Resources.line_icon));
        }
        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.BackgroundImage = ((Image)(Properties.Resources.hover_img));
        }
        private void button_Leave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }
        private void btnccpanel_MouseMove(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.Image = ((Image)(Properties.Resources.ccpanel_icon_h));
        }
        private void btnccpanel_Leave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.Image = ((Image)(Properties.Resources.ccpanel_icon));
        }
        private void btnhelp_MouseMove(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.BackgroundImage = ((Image)(Properties.Resources.help_icon_h));
        }
        private void btnhelp_Leave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.BackgroundImage = ((Image)(Properties.Resources.help_icon));
        }
        private void btnfb_MouseMove(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.Image = ((Image)(Properties.Resources.fb_icon_h));
        }
        private void btnfb_Leave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.Image = ((Image)(Properties.Resources.fb_icon));
        }
        private void btnsettings_MouseMove(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.BackgroundImage = ((Image)(Properties.Resources.settings_icon_h));
        }
        private void btnsettings_Leave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.BackgroundImage = ((Image)(Properties.Resources.settings_icon));
        }

        //audio for events
        public static void goodsound()
        {
            SoundPlayer audio = new SoundPlayer(tsrvtcnew.Properties.Resources.good); //sound for process completed
            audio.Play();
        }
        public static void errorsound()
        {
            SoundPlayer audio = new SoundPlayer(tsrvtcnew.Properties.Resources.error); //sound for error
            audio.Play();
        }
        public static void truckhorn()
        {
            SoundPlayer audio = new SoundPlayer(tsrvtcnew.Properties.Resources.truck_horn); //sound for truck horn
            audio.Play();
        }

        //timer checks, this must stay false unless user changes through the program
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
                timer.min = 0;
                calc_check = false;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
                timer.min = 60;
                calc_check = true;
            }
        }

        //opens cconvoy control panel... 
        private void btnccpanel_Click(object sender, EventArgs e)
        {
            ccpanel newf = new ccpanel();
            newf.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void txttime_TextChanged(object sender, EventArgs e)
        {
            timeconvert = Int32.Parse(txttime.Text);                //changed from having a set button to it being automatically updated
        }

        private void txtmessage_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.message = txtmessage.Text;      //changed from having a save button to it being automatically updated
            Properties.Settings.Default.Save();
        }

        private void picbcreatedfor_Click(object sender, EventArgs e)
        {

        }
    }
}
