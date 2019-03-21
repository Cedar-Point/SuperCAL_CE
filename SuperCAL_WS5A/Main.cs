using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace SuperCAL_CE
{
    public partial class Main : Form
    {
        [DllImport("coredll.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        public Main()
        {
            InitializeComponent();
            Logger.LogTB = LogTB;
            hWnd = Handle;
            SetWindowsPosition((Screen.PrimaryScreen.Bounds.Width / 2) - (Width / 2), (Screen.PrimaryScreen.Bounds.Height / 2) - (Height / 2));
        }

        private static IntPtr hWnd;

        private static void SetWindowsPosition(int x, int y)
        {
            try
            {
                SetWindowPos(hWnd, IntPtr.Zero, x, y, 0, 0, 0x0001);
            }
            catch(Exception)
            {
                Console.WriteLine("Failed to set window position.");
            }
        }


        private void Main_Load(object sender, EventArgs e)
        {
            Logger.Log("Welcome to Super CAL: Press any button to begin.");
        }


        private void ReCAL_Click(object sender, EventArgs e)
        {
            Misc.StopCAL();
        }

        private void StopStartCAL_Click(object sender, EventArgs e)
        {
            Misc.IsCalStarted();
        }
    }
}
