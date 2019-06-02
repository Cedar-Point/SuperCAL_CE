using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperCAL_CE
{
    public partial class Pin : UserControl
    {
        public static string UnlockPin = "";
        public static string UnlockMessage = "";
        private string pinBuffer = "";
        public Pin()
        {
            InitializeComponent();
        }
        private void UpdateDisplay()
        {
            string starDisplay = "";
            for (int count = 0; count != pinBuffer.Length; count++)
            {
                starDisplay += '*';
            }
            btnDisplay.Text = starDisplay;
        }

        private void BTN_Click(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            if (thisButton.Text == "Enter")
            {
                if(pinBuffer == UnlockPin)
                {
                    Hide();
                }
            }
            else
            {
                pinBuffer += thisButton.Text;
                UpdateDisplay();
            }
        }
    }
}
