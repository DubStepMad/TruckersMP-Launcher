namespace tsrvtcnew
{
    partial class Settings
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
            this.btnselect = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cb_tb = new System.Windows.Forms.CheckBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.cb_etssingle = new System.Windows.Forms.CheckBox();
            this.cb_rgui = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtguidesc
            // 
            this.txtguidesc.BackColor = System.Drawing.Color.DarkGray;
            this.txtguidesc.Enabled = false;
            this.txtguidesc.Font = new System.Drawing.Font("Hemi Head Rg", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtguidesc.ForeColor = System.Drawing.Color.Black;
            this.txtguidesc.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtguidesc.Location = new System.Drawing.Point(7, 56);
            this.txtguidesc.Name = "txtguidesc";
            this.txtguidesc.ReadOnly = true;
            this.txtguidesc.Size = new System.Drawing.Size(69, 21);
            this.txtguidesc.TabIndex = 19;
            this.txtguidesc.Text = "GUI Folder";
            this.txtguidesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtdatapath
            // 
            this.txtdatapath.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtdatapath.Location = new System.Drawing.Point(92, 58);
            this.txtdatapath.Name = "txtdatapath";
            this.txtdatapath.ReadOnly = true;
            this.txtdatapath.Size = new System.Drawing.Size(386, 20);
            this.txtdatapath.TabIndex = 18;
            // 
            // btnselect
            // 
            this.btnselect.BackColor = System.Drawing.Color.DarkGray;
            this.btnselect.Font = new System.Drawing.Font("Hemi Head Rg", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnselect.Location = new System.Drawing.Point(399, 93);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(39, 19);
            this.btnselect.TabIndex = 14;
            this.btnselect.Text = "Edit";
            this.btnselect.UseVisualStyleBackColor = false;
            this.btnselect.Click += new System.EventHandler(this.Btnselect_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::tsrvtcnew.Properties.Resources.settings;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(178, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 24);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Settings_MouseDown);
            // 
            // cb_tb
            // 
            this.cb_tb.AutoSize = true;
            this.cb_tb.BackColor = System.Drawing.Color.DarkGray;
            this.cb_tb.FlatAppearance.BorderColor = System.Drawing.SystemColors.Menu;
            this.cb_tb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_tb.Font = new System.Drawing.Font("Hemi Head Rg", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_tb.ForeColor = System.Drawing.Color.Black;
            this.cb_tb.Location = new System.Drawing.Point(7, 91);
            this.cb_tb.Name = "cb_tb";
            this.cb_tb.Size = new System.Drawing.Size(89, 17);
            this.cb_tb.TabIndex = 28;
            this.cb_tb.Text = "TrucksBook";
            this.cb_tb.UseVisualStyleBackColor = false;
            this.cb_tb.CheckedChanged += new System.EventHandler(this.Cb_tb_CheckedChanged);
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.Color.DarkGray;
            this.btn_reset.Font = new System.Drawing.Font("Hemi Head Rg", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.ForeColor = System.Drawing.Color.Black;
            this.btn_reset.Location = new System.Drawing.Point(441, 91);
            this.btn_reset.Margin = new System.Windows.Forms.Padding(0);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(50, 23);
            this.btn_reset.TabIndex = 29;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.Btn_reset_Click);
            // 
            // cb_etssingle
            // 
            this.cb_etssingle.AutoSize = true;
            this.cb_etssingle.BackColor = System.Drawing.Color.DarkGray;
            this.cb_etssingle.FlatAppearance.BorderColor = System.Drawing.SystemColors.Menu;
            this.cb_etssingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_etssingle.Font = new System.Drawing.Font("Hemi Head Rg", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_etssingle.ForeColor = System.Drawing.Color.Black;
            this.cb_etssingle.Location = new System.Drawing.Point(102, 91);
            this.cb_etssingle.Name = "cb_etssingle";
            this.cb_etssingle.Size = new System.Drawing.Size(129, 17);
            this.cb_etssingle.TabIndex = 30;
            this.cb_etssingle.Text = "ETS 2 Single Player";
            this.cb_etssingle.UseVisualStyleBackColor = false;
            this.cb_etssingle.CheckedChanged += new System.EventHandler(this.Cb_etssingle_CheckedChanged);
            // 
            // cb_rgui
            // 
            this.cb_rgui.AutoSize = true;
            this.cb_rgui.BackColor = System.Drawing.Color.DarkGray;
            this.cb_rgui.FlatAppearance.BorderColor = System.Drawing.SystemColors.Menu;
            this.cb_rgui.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_rgui.Font = new System.Drawing.Font("Hemi Head Rg", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_rgui.ForeColor = System.Drawing.Color.Black;
            this.cb_rgui.Location = new System.Drawing.Point(237, 91);
            this.cb_rgui.Name = "cb_rgui";
            this.cb_rgui.Size = new System.Drawing.Size(84, 17);
            this.cb_rgui.TabIndex = 31;
            this.cb_rgui.Text = "Custom GUI";
            this.cb_rgui.UseVisualStyleBackColor = false;
            this.cb_rgui.CheckedChanged += new System.EventHandler(this.Cb_rgui_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::tsrvtcnew.Properties.Resources.cross;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(479, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(17, 17);
            this.button1.TabIndex = 45;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseLeave += new System.EventHandler(this.Mouse1_Leave);
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button1_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::tsrvtcnew.Properties.Resources.black_strip;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(0, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(501, 22);
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(500, 118);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cb_rgui);
            this.Controls.Add(this.cb_etssingle);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.cb_tb);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtguidesc);
            this.Controls.Add(this.txtdatapath);
            this.Controls.Add(this.btnselect);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.Text = "settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Settings_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtguidesc;
        private System.Windows.Forms.TextBox txtdatapath;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.CheckBox cb_tb;
        private System.Windows.Forms.Button btn_reset;
        public System.Windows.Forms.CheckBox cb_etssingle;
        public System.Windows.Forms.CheckBox cb_rgui;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}