namespace tsrvtcnew
{
    partial class tc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tc));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_tc = new System.Windows.Forms.Button();
            this.btn_agree = new System.Windows.Forms.Button();
            this.btn_disagree = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(31, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.ShortcutsEnabled = false;
            this.richTextBox1.ShowSelectionMargin = true;
            this.richTextBox1.Size = new System.Drawing.Size(276, 162);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // btn_tc
            // 
            this.btn_tc.Location = new System.Drawing.Point(31, 192);
            this.btn_tc.Name = "btn_tc";
            this.btn_tc.Size = new System.Drawing.Size(71, 23);
            this.btn_tc.TabIndex = 2;
            this.btn_tc.Text = "Terms";
            this.btn_tc.UseVisualStyleBackColor = true;
            this.btn_tc.Click += new System.EventHandler(this.btn_tc_Click);
            // 
            // btn_agree
            // 
            this.btn_agree.Location = new System.Drawing.Point(212, 192);
            this.btn_agree.Name = "btn_agree";
            this.btn_agree.Size = new System.Drawing.Size(46, 23);
            this.btn_agree.TabIndex = 3;
            this.btn_agree.Text = "Agree";
            this.btn_agree.UseVisualStyleBackColor = true;
            this.btn_agree.Click += new System.EventHandler(this.btn_agree_Click);
            // 
            // btn_disagree
            // 
            this.btn_disagree.Location = new System.Drawing.Point(270, 192);
            this.btn_disagree.Name = "btn_disagree";
            this.btn_disagree.Size = new System.Drawing.Size(58, 23);
            this.btn_disagree.TabIndex = 4;
            this.btn_disagree.Text = "Disagree";
            this.btn_disagree.UseVisualStyleBackColor = true;
            this.btn_disagree.Click += new System.EventHandler(this.btn_disagree_Click);
            // 
            // tc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 227);
            this.Controls.Add(this.btn_disagree);
            this.Controls.Add(this.btn_agree);
            this.Controls.Add(this.btn_tc);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "tc";
            this.Text = "tc";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.tc_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_tc;
        private System.Windows.Forms.Button btn_agree;
        private System.Windows.Forms.Button btn_disagree;
    }
}