namespace tsrvtcnew
{
    partial class settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtguidesc = new System.Windows.Forms.TextBox();
            this.txtdatapath = new System.Windows.Forms.TextBox();
            this.btnselectdata = new System.Windows.Forms.Button();
            this.txtdescrip = new System.Windows.Forms.TextBox();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.btnselect = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.cb_tb = new System.Windows.Forms.CheckBox();
            this.btn_reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtguidesc
            // 
            this.txtguidesc.BackColor = System.Drawing.Color.DarkGray;
            this.txtguidesc.Enabled = false;
            this.txtguidesc.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F);
            this.txtguidesc.ForeColor = System.Drawing.SystemColors.Window;
            this.txtguidesc.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtguidesc.Location = new System.Drawing.Point(8, 86);
            this.txtguidesc.Name = "txtguidesc";
            this.txtguidesc.ReadOnly = true;
            this.txtguidesc.Size = new System.Drawing.Size(102, 20);
            this.txtguidesc.TabIndex = 19;
            this.txtguidesc.Text = "GUI Folder";
            this.txtguidesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtdatapath
            // 
            this.txtdatapath.Location = new System.Drawing.Point(137, 87);
            this.txtdatapath.Name = "txtdatapath";
            this.txtdatapath.Size = new System.Drawing.Size(367, 20);
            this.txtdatapath.TabIndex = 18;
            // 
            // btnselectdata
            // 
            this.btnselectdata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnselectdata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnselectdata.Location = new System.Drawing.Point(510, 87);
            this.btnselectdata.Name = "btnselectdata";
            this.btnselectdata.Size = new System.Drawing.Size(31, 20);
            this.btnselectdata.TabIndex = 17;
            this.btnselectdata.Text = "...";
            this.btnselectdata.UseVisualStyleBackColor = true;
            this.btnselectdata.Click += new System.EventHandler(this.btnselectdata_Click);
            // 
            // txtdescrip
            // 
            this.txtdescrip.BackColor = System.Drawing.Color.DarkGray;
            this.txtdescrip.Enabled = false;
            this.txtdescrip.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F);
            this.txtdescrip.ForeColor = System.Drawing.SystemColors.Window;
            this.txtdescrip.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtdescrip.Location = new System.Drawing.Point(8, 61);
            this.txtdescrip.Name = "txtdescrip";
            this.txtdescrip.ReadOnly = true;
            this.txtdescrip.Size = new System.Drawing.Size(102, 20);
            this.txtdescrip.TabIndex = 16;
            this.txtdescrip.Text = "Launcher Folder";
            // 
            // txtpath
            // 
            this.txtpath.ForeColor = System.Drawing.Color.Black;
            this.txtpath.Location = new System.Drawing.Point(137, 61);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(367, 20);
            this.txtpath.TabIndex = 15;
            // 
            // btnselect
            // 
            this.btnselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnselect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnselect.Location = new System.Drawing.Point(510, 61);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(31, 20);
            this.btnselect.TabIndex = 14;
            this.btnselect.Text = "...";
            this.btnselect.UseVisualStyleBackColor = true;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Transparent;
            this.btnsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.btnsave.Image = global::tsrvtcnew.Properties.Resources.save_icon;
            this.btnsave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnsave.Location = new System.Drawing.Point(519, 122);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(22, 23);
            this.btnsave.TabIndex = 20;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            this.btnsave.MouseLeave += new System.EventHandler(this.btnsave_Leave);
            this.btnsave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnsave_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::tsrvtcnew.Properties.Resources.settings;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(196, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 36);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.settings_MouseDown);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Image = global::tsrvtcnew.Properties.Resources.cross_512;
            this.btnclose.Location = new System.Drawing.Point(528, -1);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(27, 25);
            this.btnclose.TabIndex = 26;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            this.btnclose.MouseLeave += new System.EventHandler(this.btnclose_Leave);
            this.btnclose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnclose_MouseMove);
            // 
            // cb_tb
            // 
            this.cb_tb.AutoSize = true;
            this.cb_tb.BackColor = System.Drawing.Color.DarkGray;
            this.cb_tb.FlatAppearance.BorderColor = System.Drawing.SystemColors.Menu;
            this.cb_tb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_tb.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.cb_tb.Location = new System.Drawing.Point(10, 131);
            this.cb_tb.Name = "cb_tb";
            this.cb_tb.Size = new System.Drawing.Size(81, 17);
            this.cb_tb.TabIndex = 28;
            this.cb_tb.Text = "TrucksBook";
            this.cb_tb.UseVisualStyleBackColor = false;
            this.cb_tb.CheckedChanged += new System.EventHandler(this.cb_tb_CheckedChanged);
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.Color.DarkGray;
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset.ForeColor = System.Drawing.SystemColors.Menu;
            this.btn_reset.Location = new System.Drawing.Point(458, 125);
            this.btn_reset.Margin = new System.Windows.Forms.Padding(0);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(46, 23);
            this.btn_reset.TabIndex = 29;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::tsrvtcnew.Properties.Resources.settings_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(554, 157);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.cb_tb);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtguidesc);
            this.Controls.Add(this.txtdatapath);
            this.Controls.Add(this.btnselectdata);
            this.Controls.Add(this.txtdescrip);
            this.Controls.Add(this.txtpath);
            this.Controls.Add(this.btnselect);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "settings";
            this.Text = "settings";
            this.Load += new System.EventHandler(this.settings_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.settings_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtguidesc;
        private System.Windows.Forms.TextBox txtdatapath;
        private System.Windows.Forms.Button btnselectdata;
        private System.Windows.Forms.TextBox txtdescrip;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnclose;
        public System.Windows.Forms.CheckBox cb_tb;
        private System.Windows.Forms.Button btn_reset;
    }
}