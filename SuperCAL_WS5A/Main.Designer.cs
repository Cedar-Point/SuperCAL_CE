namespace SuperCAL_CE
{
    partial class Main
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
            this.ReCAL = new System.Windows.Forms.Button();
            this.ReDownloadCAL = new System.Windows.Forms.Button();
            this.StopStartCAL = new System.Windows.Forms.Button();
            this.LogTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ReCAL
            // 
            this.ReCAL.Location = new System.Drawing.Point(6, 27);
            this.ReCAL.Name = "ReCAL";
            this.ReCAL.Size = new System.Drawing.Size(112, 69);
            this.ReCAL.TabIndex = 1;
            this.ReCAL.Text = "Re CAL";
            this.ReCAL.Click += new System.EventHandler(this.ReCAL_Click);
            // 
            // ReDownloadCAL
            // 
            this.ReDownloadCAL.Location = new System.Drawing.Point(124, 27);
            this.ReDownloadCAL.Name = "ReDownloadCAL";
            this.ReDownloadCAL.Size = new System.Drawing.Size(124, 69);
            this.ReDownloadCAL.TabIndex = 2;
            this.ReDownloadCAL.Text = "Re Download";
            this.ReDownloadCAL.Click += new System.EventHandler(this.ReDownloadCAL_Click);
            // 
            // StopStartCAL
            // 
            this.StopStartCAL.Location = new System.Drawing.Point(254, 27);
            this.StopStartCAL.Name = "StopStartCAL";
            this.StopStartCAL.Size = new System.Drawing.Size(113, 69);
            this.StopStartCAL.TabIndex = 3;
            this.StopStartCAL.Text = "CAL Srvc Toggle";
            this.StopStartCAL.Click += new System.EventHandler(this.StopStartCAL_Click);
            // 
            // LogTB
            // 
            this.LogTB.Location = new System.Drawing.Point(6, 104);
            this.LogTB.Multiline = true;
            this.LogTB.Name = "LogTB";
            this.LogTB.ReadOnly = true;
            this.LogTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTB.Size = new System.Drawing.Size(361, 329);
            this.LogTB.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(373, 440);
            this.Controls.Add(this.ReCAL);
            this.Controls.Add(this.ReDownloadCAL);
            this.Controls.Add(this.StopStartCAL);
            this.Controls.Add(this.LogTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Super CAL (CE)";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ReCAL;
        private System.Windows.Forms.Button ReDownloadCAL;
        private System.Windows.Forms.Button StopStartCAL;
        private System.Windows.Forms.TextBox LogTB;
    }
}