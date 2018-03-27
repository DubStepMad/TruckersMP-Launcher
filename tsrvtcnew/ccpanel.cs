using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using MySql.Data.MySqlClient;

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
            this.bw.DoWork += new DoWorkEventHandler(Bw_DoWork);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_RunWorkerCompleted);
            RegisterHotKey(this.Handle, ccpanel_hotmey_ID, 4, (int)Keys.Y);

        }

        private void Ccpanel_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.ccpanelcheck = true;
            Properties.Settings.Default.Save();
        }

        private void LoadDataBaseValue(string point)
        {
            try
            {
                MySqlConnection connectionMySQL = new MySqlConnection("server=185.44.78.200;uid=tsrvtcco_client;password=PhjMKiZEW0I2oxSFDP;database=tsrvtcco_tsr-vtc;");
                try
                {
                    connectionMySQL.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM points WHERE uid=" + point, connectionMySQL);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
                    message = rdr.GetString("message");
                    txtb_message.Text = "**TSRV CONVOY** " + message;
                    message = txtb_message.Text.ToString();
                    rdr.Close();
                    connectionMySQL.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            catch (Exception es)

            {
                MessageBox.Show(es.Message);
            }
        }

        // Needs to be added to the database
       /* private void Loadtext()
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
        }*/

        private void Ccpanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ccpanelcheck = false;
            Properties.Settings.Default.Save();
        }

        private void Ccpanel_MouseDown(object sender,
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
                    Form1.Goodsound();
                    this.bw.RunWorkerAsync();
                    this.bw.WorkerSupportsCancellation = true;
                }
                if (setbusy == true)
                {
                    setbusy = false;
                    this.bw.CancelAsync();
                    Form1.Truckhorn();
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            setbusy = false;
            this.bw.CancelAsync();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
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
                    Timer.Ccpanel_action(); //Keyboard input and custom wait delay
                }
            }
        }

        //radio button passes tag
        private void AnyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            string point = (string)radio.Tag;
            LoadDataBaseValue(point);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btnmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Button1_Leave(object sender, EventArgs e)
        {
            this.button1.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }
        void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.button1.BackgroundImage = ((Image)(Properties.Resources.cross_hover));
        }
        private void Btnmini_Leave(object sender, EventArgs e)
        {
            this.btnmini.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }
        void Btnmini_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnmini.BackgroundImage = ((Image)(Properties.Resources.line_icon));
        }
    }
}
