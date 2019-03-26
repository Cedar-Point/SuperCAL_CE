using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
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
            InitializeMainMenu();
            InitializeComponent();
            Logger.LogTB = LogTB;
            hWnd = Handle;
            CenterWindow();
            topTimer.Interval = 1000;
            topTimer.Tick += TopTimer_Tick;
            topTimer.Enabled = true;
        }
        private static void SetWindowPosition(int x, int y)
        {
            try
            {
                SetWindowPos(hWnd, IntPtr.Zero, x, y, 0, 0, 0x0001);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to set window position.");
            }
        }
        private void CenterWindow(int xOffset = 0, int yOffset = 0)
        {
            SetWindowPosition((Screen.PrimaryScreen.Bounds.Width / 2) - (Width / 2) + xOffset, (Screen.PrimaryScreen.Bounds.Height / 2) - (Height / 2) + yOffset);
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
            try
            {
                Config.ReadConfig();
                Logger.Log("Welcome to Super CAL: Press any button to begin.");
                ToggleCalSvc(true);
            }
            catch(Exception)
            {
                Menu = null;
                ReCAL.Enabled = ReDownloadCAL.Enabled = StopStartCAL.Enabled = false;
                Logger.Error("A fatal error occured. Check the SuperCAL_CE.xml configuration. Also, make sure SuperCAL CE is running on Windows CE 6+ with .NET Compact Framework 3.5.");
            }
        }

        private void ReCAL_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Misc.StopCAL();
            ToggleCalSvc(true);
            Wipe.Do(false);
            Misc.StartCAL();
            ToggleCalSvc(true);
            CenterWindow(-330);
            Cursor.Current = Cursors.Default;
        }

        private void StopStartCAL_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ToggleCalSvc();
            Cursor.Current = Cursors.Default;
        }
        private void TopTimer_Tick(object sender, EventArgs e)
        {
            BringToFront();
        }

        private void ReDownloadCAL_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Misc.StopCAL();
            ToggleCalSvc(true);
            Wipe.Do(true);
            Misc.StartCAL();
            ToggleCalSvc(true);
            CenterWindow(-330);
            Cursor.Current = Cursors.Default;
        }

        private void PerformLayout() { }
    }
}
