using System;
using System.Windows.Forms;

namespace tsrvtcnew
{
    public partial class tc : Form
    {
        public tc()
        {
            InitializeComponent();
        }

        private void btn_tc_Click(object sender, EventArgs e)
        {
            string filename = "terms.txt";
            if (!System.IO.File.Exists(filename))
                System.IO.File.WriteAllText(filename, Properties.Resources.terms);
            // let windows decide which program it will use to open the file ...
            // whatever registered application for .txt extension is on the user system
            System.Diagnostics.Process.Start(filename);
        }

        private void btn_agree_Click(object sender, EventArgs e)
        {
            this.Close();
            Properties.Settings.Default.agreed = true;
            Properties.Settings.Default.Save();
        }

        private void btn_disagree_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void tc_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Properties.Settings.Default.agreed == false)
            {
                Application.Exit();
            }
        }
    }
}
