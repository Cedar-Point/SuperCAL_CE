namespace SuperCAL_CE
{
    partial class Pin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReCAL = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReCAL
            // 
            this.ReCAL.Location = new System.Drawing.Point(25, 129);
            this.ReCAL.Name = "ReCAL";
            this.ReCAL.Size = new System.Drawing.Size(102, 65);
            this.ReCAL.TabIndex = 2;
            this.ReCAL.Text = "7";
            this.ReCAL.Click += new System.EventHandler(this.BTN_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 65);
            this.button1.TabIndex = 3;
            this.button1.Text = "8";
            this.button1.Click += new System.EventHandler(this.BTN_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(241, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 65);
            this.button2.TabIndex = 4;
            this.button2.Text = "9";
            this.button2.Click += new System.EventHandler(this.BTN_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(25, 200);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 65);
            this.button3.TabIndex = 5;
            this.button3.Text = "4";
            this.button3.Click += new System.EventHandler(this.BTN_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(133, 200);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 65);
            this.button4.TabIndex = 6;
            this.button4.Text = "5";
            this.button4.Click += new System.EventHandler(this.BTN_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(241, 200);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 65);
            this.button5.TabIndex = 7;
            this.button5.Text = "6";
            this.button5.Click += new System.EventHandler(this.BTN_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(25, 271);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(102, 65);
            this.button6.TabIndex = 8;
            this.button6.Text = "1";
            this.button6.Click += new System.EventHandler(this.BTN_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(133, 271);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(102, 65);
            this.button7.TabIndex = 9;
            this.button7.Text = "2";
            this.button7.Click += new System.EventHandler(this.BTN_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(241, 271);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(102, 65);
            this.button8.TabIndex = 10;
            this.button8.Text = "3";
            this.button8.Click += new System.EventHandler(this.BTN_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(25, 342);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(102, 65);
            this.button9.TabIndex = 11;
            this.button9.Text = "0";
            this.button9.Click += new System.EventHandler(this.BTN_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(133, 342);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(210, 65);
            this.button10.TabIndex = 12;
            this.button10.Text = "Enter";
            this.button10.Click += new System.EventHandler(this.BTN_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackColor = System.Drawing.Color.White;
            this.btnDisplay.Enabled = false;
            this.btnDisplay.Location = new System.Drawing.Point(25, 22);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(318, 101);
            this.btnDisplay.TabIndex = 14;
            this.btnDisplay.Text = "Enter Unlock PIN";
            // 
            // Pin
            // 
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ReCAL);
            this.Name = "Pin";
            this.Size = new System.Drawing.Size(368, 432);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReCAL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btnDisplay;
    }
}
