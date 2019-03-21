using System;
using System.Windows.Forms;

namespace SuperCAL_CE
{
    class Logger
    {
        public static TextBox LogTB;
        public static void Log(string message)
        {
            WriteLine(message, "SuperCAL> ");
        }
        public static void Good(string message)
        {
            WriteLine(message, "SUCCESS> ");
        }
        public static void Warning(string message)
        {
            WriteLine(message, "WARNING> ");
        }
        public static void Error(string message)
        {
            WriteLine(message, "ERROR> ");
        }
        private static void WriteLine(string message, string prefix = "")
        {
            LogTB.Text = LogTB.Text + prefix + DateTime.Now.ToLocalTime().ToShortTimeString() + ": " + message + '\r';
            LogTB.ScrollToCaret();
        }
    }
}
