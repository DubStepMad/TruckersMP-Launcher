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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settings));
            this.txtguidesc = new System.Windows.Forms.TextBox();
            this.txtdatapath = new System.Windows.Forms.TextBox();
            this.btnselect = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.cb_tb = new System.Windows.Forms.CheckBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.cb_etssingle = new System.Windows.Forms.CheckBox();
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
            this.txtguidesc.Location = new System.Drawing.Point(8, 64);
            this.txtguidesc.Name = "txtguidesc";
            this.txtguidesc.ReadOnly = true;
            this.txtguidesc.Size = new System.Drawing.Size(102, 20);
            this.txtguidesc.TabIndex = 19;
            this.txtguidesc.Text = "GUI Folder";
            this.txtguidesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtdatapath
            // 
            this.txtdatapath.Location = new System.Drawing.Point(116, 65);
            this.txtdatapath.Name = "txtdatapath";
            this.txtdatapath.ReadOnly = true;
            this.txtdatapath.Size = new System.Drawing.Size(367, 20);
            this.txtdatapath.TabIndex = 18;
            // 
            // btnselect
            // 
            this.btnselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnselect.Location = new System.Drawing.Point(495, 65);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(39, 19);
            this.btnselect.TabIndex = 14;
            this.btnselect.Text = "Edit";
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
            this.btnclose.Image = global::tsrvtcnew.Properties.Resources.cross;
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
            // cb_etssingle
            // 
            this.cb_etssingle.AutoSize = true;
            this.cb_etssingle.BackColor = System.Drawing.Color.DarkGray;
            this.cb_etssingle.FlatAppearance.BorderColor = System.Drawing.SystemColors.Menu;
            this.cb_etssingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_etssingle.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.cb_etssingle.Location = new System.Drawing.Point(97, 131);
            this.cb_etssingle.Name = "cb_etssingle";
            this.cb_etssingle.Size = new System.Drawing.Size(117, 17);
            this.cb_etssingle.TabIndex = 30;
            this.cb_etssingle.Text = "ETS 2 Single Player";
            this.cb_etssingle.UseVisualStyleBackColor = false;
            this.cb_etssingle.CheckedChanged += new System.EventHandler(this.cb_etssingle_CheckedChanged);
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(554, 157);
            this.Controls.Add(this.cb_etssingle);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.cb_tb);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtguidesc);
            this.Controls.Add(this.txtdatapath);
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
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnclose;
        public System.Windows.Forms.CheckBox cb_tb;
        private System.Windows.Forms.Button btn_reset;
        public System.Windows.Forms.CheckBox cb_etssingle;
    }
}