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

        //variables
        public static int timeconvert;
        public static bool setbusy = false;
        public static string Check = "";
        public static bool calc_check;

        public Form1()
        {
            InitializeComponent();

            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(Bw_DoWork);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_RunWorkerCompleted);

            txtmessage.Text = Properties.Settings.Default.message;

            //Ctrl + Y modifier
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 2, (int)Keys.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.agreed == false)
            {
                tc tc = new tc();
                tc.ShowDialog();
            }

            RegistryCheck.Read();
            Tmppdate.IntegrityCheck();

            Properties.Settings.Default.ccpanelcheck = false;
            Properties.Settings.Default.Save();

            //checks for updater.exe, needed to be a seperate program for performance reasons
            string updaterFile = (new Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string updaterDir = Path.GetDirectoryName(updaterFile);
            string fullPath = Path.Combine(updaterDir, "updater.exe");

            if (!File.Exists(fullPath))
            {
                string error = "Updater.exe not located, re-install program!";
                Loghandling.Logerror(error);
                Errorsound();
            }
            else if (File.Exists(Path.Combine(updaterDir, "updater.exe")) && fullPath != null)
            {
                Process.Start(@"updater.exe");
            }
            else
            {
                string error = "Error reading paths!!";
                Loghandling.Logerror(error);
                Errorsound();
            }
        }

        //creates new thread to run the looped process, this also has a few important checks
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID && Properties.Settings.Default.ccpanelcheck == false)
            {
                Clipboard.SetText(txtmessage.Text);

                Thread.Sleep(1000); // sleep needed to allow time to copy text from text box otherwise it won't

                if (!bw.IsBusy && setbusy == false) //2 flags needed since both need to come back false
                {
                    Goodsound();
                    setbusy = true;
                    bw.RunWorkerAsync();
                    bw.WorkerSupportsCancellation = true;
                }
                else if (bw.IsBusy && setbusy == true) //checks only one variable is true, bw.Isbusy could be checked if true too
                {
                    setbusy = false;
                    bw.CancelAsync();
                    Truckhorn();
                    return;
                }
                else if (timeconvert <= 0 ) //check to make sure the time entered does not equal 0 and cause spamming in-game chat
                {
                    setbusy = false;
                    bw.CancelAsync();
                    Truckhorn();
                    MessageBox.Show("Please enter a number into the timer field above 0!");
                    return;
                }
                else
                {
                    MessageBox.Show("Known issue trying to be fixed, please re-start the application");
                    string error = "Background Worker Exit Failed!";
                    Loghandling.Logerror(error);
                    Errorsound();
                }
            }
            base.WndProc(ref m);
        }

        //method called when the background worker needs to be cancelled correctly without a dead end stop
        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            setbusy = false;
            this.bw.CancelAsync();
        }

        //method called within to start the new thread and compelte the task
        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            for (int i = 0; i < 100; ++i)
            {
                if ((worker.CancellationPending == true)) //check to see if the background worker is already active
                {
                    e.Cancel = true;
                    this.bw.CancelAsync();
                }
                else
                {

                    Timer.Calculate(); //Keyboard input and custom wait delay
                }
            }
        }

        //allows the form to be moved
        private void Form1_MouseDown(object sender,
        MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public bool Start_message { get; private set; }

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Btnltmp_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.replacegui == true)
            {
                Gui_replace();
            }

            GameHandle.Launch();
        }

        public static void Gui_replace()
        {
            string SourcePath = (Properties.Settings.Default.datapath);
            string DesPath = ("C:/ProgramData/TruckersMP");

            //gets application directory
            string exeFile = (new Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            string finalPath = Path.Combine(exeDir, "custom gui");

            if (finalPath == null)
            {
                MessageBox.Show("Application must be ran as an Administrator!");
                Errorsound();
                return;
            }

            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(DesPath + dirPath.Remove(0, SourcePath.Length));

            foreach (String newPath in Directory.GetFiles(SourcePath, "*.*",
                    SearchOption.AllDirectories))
                File.Copy(newPath, DesPath + newPath.Remove(0, SourcePath.Length), true);
            Goodsound();
            return;
        }

        //small button functions
        //button hover overs and resets
        private void Btnhelp_Click(object sender, EventArgs e)
        {
            Help hp = new Help();
            hp.ShowDialog();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Settings ss = new Settings();
            ss.ShowDialog();
        }
        private void Btnfb_Click(object sender, EventArgs e)
        {
            Process.Start("www.facebook.com/TSRVTC/");
        }
        private void Btndiscord_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/VXzCurC");
        }
        private void Btn_pp_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.me/ConnorNee97");
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Button1_Leave(object sender, EventArgs e)
        {
            this.button1.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }
        void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.button1.BackgroundImage = ((Image)(Properties.Resources.cross_hover));
        }
        private void Btnmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Btnmini_Leave(object sender, EventArgs e)
        {
            this.btnmini.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }
        void Btnmini_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnmini.BackgroundImage = ((Image)(Properties.Resources.line_icon));
        }
        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.BackgroundImage = ((Image)(Properties.Resources.hover_img));
        }
        private void Button_Leave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }
        private void Btnccpanel_MouseMove(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.Image = ((Image)(Properties.Resources.ccpanel_icon_h));
        }
        private void Btnccpanel_Leave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.Image = ((Image)(Properties.Resources.ccpanel_icon));
        }
        private void Btnhelp_MouseMove(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.BackgroundImage = ((Image)(Properties.Resources.help_icon_h));
        }
        private void Btnhelp_Leave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.BackgroundImage = ((Image)(Properties.Resources.help_icon));
        }
        private void Btnfb_MouseMove(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.Image = ((Image)(Properties.Resources.fb_icon_h));
        }
        private void Btnfb_Leave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.Image = ((Image)(Properties.Resources.fb_icon));
        }
        private void Btnsettings_MouseMove(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.BackgroundImage = ((Image)(Properties.Resources.settings_icon_h));
        }
        private void Btnsettings_Leave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.BackgroundImage = ((Image)(Properties.Resources.settings_icon));
        }

        //audio for events
        public static void Goodsound()
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.good); //sound for process completed
            audio.Play();
        }
        public static void Errorsound()
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.error); //sound for error
            audio.Play();
        }
        public static void Truckhorn()
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.truck_horn); //sound for truck horn
            audio.Play();
        }

        //timer checks
        private void RadioButton1_CheckedChanged(object sender, EventArgs e) //timer in (seconds)
        {
            if (radioButton1.Checked)
            {
                Properties.Settings.Default.message = txtmessage.Text;      //changed from having a save button to it being automatically updated
                Properties.Settings.Default.Save();

                radioButton2.Checked = false;
                radioButton3.Checked = false;
                timeconvert = 5;
                Timer.Min = 0;
                calc_check = false;
            }
        }
        private void RadioButton2_CheckedChanged(object sender, EventArgs e) //timer in (minutes)
        {
            if (radioButton2.Checked)
            {
                string advertisement = "Looking to join a VTC? Come and join us on DISCORD @ discord.tsrvtc.com  and speak to an examiner!";

                txtmessage.Text = advertisement;
                Properties.Settings.Default.message = advertisement;      //changed from having a save button to it being automatically updated
                Properties.Settings.Default.Save();

                radioButton1.Checked = false;
                radioButton3.Checked = false;
                timeconvert = 7;
                Timer.Min = 60;
                calc_check = true;
            }
        }
        private void RadioButton3_CheckedChanged(object sender, EventArgs e) //timer in (minutes)
        {
            if (radioButton3.Checked)
            {
                string afk = "/p";

                txtmessage.Text = afk;

                radioButton1.Checked = false;
                radioButton2.Checked = false;
                timeconvert = 7;
                Timer.Min = 60;
                calc_check = true;
            }
        }

        //opens cconvoy control panel... 
        private void Btnccpanel_Click(object sender, EventArgs e)
        {
            ccpanel newf = new ccpanel();
            newf.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void Txtmessage_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.message = txtmessage.Text;      //changed from having a save button to it being automatically updated
            Properties.Settings.Default.Save();
        }
    }
}
