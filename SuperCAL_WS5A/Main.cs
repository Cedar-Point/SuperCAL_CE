using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace SuperCAL_CE
{
    public partial class Main : Form
    {
        [DllImport("coredll.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        private static IntPtr hWnd;
        public Timer topTimer = new Timer();
        public Main()
        {
            InitializeComponent();
            Logger.LogTB = LogTB;
            hWnd = Handle;
            SetWindowsPosition((Screen.PrimaryScreen.Bounds.Width / 2) - (Width / 2), (Screen.PrimaryScreen.Bounds.Height / 2) - (Height / 2));
            topTimer.Interval = 1000;
            topTimer.Tick += TopTimer_Tick;
            topTimer.Enabled = true;
        }
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

        private void ToggleCalSvc(bool onlyCheck = false)
        {
            if (!onlyCheck)
            {
                if (Misc.IsCalStarted())
                {
                    Misc.StopCAL();
                }
                else
                {
                    Misc.StartCAL();
                }
            }
            if (Misc.IsCalStarted())
            {
                StopStartCAL.Text = "Stop CAL";
            }
            else
            {
                StopStartCAL.Text = "Start CAL";
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if(!File.Exists("SuperCAL_CE.xml"))
            {
                Config.GenerateConfig();
            }
            Config.ReadConfig();
            Logger.Log("Welcome to Super CAL: Press any button to begin.");
            ToggleCalSvc(true);
        }

        private void ReCAL_Click(object sender, EventArgs e)
        {
            Misc.StopCAL();
            ToggleCalSvc(true);
            Wipe.Do(false);
            Misc.StartCAL();
            ToggleCalSvc(true);
            /*
            foreach (ProcessCE process in ProcessCE.GetProcesses())
            {
                Logger.Log(process.baseAddress + ": " + process.handle.ToInt32() + ": " + process.processName);
            }
            */
        }

        private void StopStartCAL_Click(object sender, EventArgs e)
        {
            ToggleCalSvc();
        }
        private void TopTimer_Tick(object sender, EventArgs e)
        {
            BringToFront();
        }

        private void ReDownloadCAL_Click(object sender, EventArgs e)
        {
            Misc.StopCAL();
            ToggleCalSvc(true);
            Wipe.Do(true);
            Misc.StartCAL();
            ToggleCalSvc(true);
        }
    }
}
