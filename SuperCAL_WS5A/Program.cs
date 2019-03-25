using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SuperCAL_CE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Main());
        }
    }
}
