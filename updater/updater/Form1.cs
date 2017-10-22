using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Net;

namespace updater
{
    public partial class Form1 : Form
    {
        private BackgroundWorker bw;

        public Form1()
        {
            InitializeComponent();

            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            Instance = this;
        }

        public static Form1 Instance { get; private set; }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public static bool flag = false;


        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            if (flag == true)
            {
                pictureBox2.Image = Properties.Resources.downloading;
            }
        }

        public static void Form1_Load1()
        {
            if (flag == true)
            {
                Instance.pictureBox2.Image = Properties.Resources.downloading;
            }
        }

        public void Form1_Shown(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.checking;
            Start();
        }

        public void Start()
        {

            if (!bw.IsBusy)
            {
                pictureBox2.Image = Properties.Resources.checking;

                this.bw.RunWorkerAsync();
                this.bw.WorkerSupportsCancellation = true;
            }
            else if (bw.IsBusy)
            {
                this.bw.CancelAsync();
                return;
            }
            else
            {

            }
        }

         private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
         {
             this.bw.CancelAsync();
         }

         private void bw_DoWork(object sender, DoWorkEventArgs e)
         {
             BackgroundWorker worker = (BackgroundWorker)sender;
             if (worker.CancellationPending == true)
             {
                 e.Cancel = true;
                 return;
             }
             else
             {
                 updatehandle.Run();
             }

         }
    }
}
