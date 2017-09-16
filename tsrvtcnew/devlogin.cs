using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tsrvtcnew
{
    public partial class devlogin : Form
    {
        public devlogin()
        {
            InitializeComponent();

        }

        public string pass = "tsrvtc2k17_dub";

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txtb_pass.Text == "")
            {
                MessageBox.Show("Please enter the password or close this window!");
            }
            if (txtb_pass.Text == pass)
            {
                MessageBox.Show("Please understand the following is a work in progress and by entering the password, you agree to not share the following project without the authors permission!");
                this.Close();
                ccpanel newf = new ccpanel();
                newf.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Password!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Leave(object sender, EventArgs e)
        {
            this.button1.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }
        void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.button1.BackgroundImage = ((Image)(Properties.Resources.cross_hover));
        }
    }
}
