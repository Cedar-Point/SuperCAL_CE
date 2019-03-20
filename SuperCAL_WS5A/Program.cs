using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SuperCAL_WS5A
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

        public const Int32 INFINITE = -1;

        private static void clearMicrosRegistry()
        {
            Console.WriteLine(@"Deleting: HKLM\SOFTWARE\MICROS");
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\MICROS", true);
            foreach (string subKey in regKey.GetSubKeyNames())
            {
                regKey.DeleteSubKeyTree(subKey);
            }
            RegistryKey newKey = regKey.CreateSubKey(@"CAL\Config");
            regKey.Close();
            newKey.Close();
            Console.WriteLine(@"HKLM\SOFTWARE\MICROS: Deleted.");
        }

        private static void clearMicrosFolder()
        {
            Console.WriteLine(@"Deleting Micros from Compact Flash...");
            if (Directory.Exists(@"\CF\Micros"))
            {
                Directory.Delete(@"\CF\Micros", true);
                Console.WriteLine(@"\CF\Micros: Deleted.");
            }
            if (Directory.Exists(@"\CF\POSClient"))
            {
                Directory.Delete(@"\CF\POSClient", true);
                Console.WriteLine(@"\CF\POSClient: Deleted.");
            }
            if (Directory.Exists(@"\CF\CALTemp"))
            {
                Directory.Delete(@"\CF\CALTemp", true);
                Console.WriteLine(@"\CF\CALTemp: Deleted.");
            }
        }

        private static void startCal()
        {
            Console.WriteLine(@"Starting: Micros CAL...");
            startProcess(@"\DOC\McrsCAL\McrsCAL.exe");
            
        }

        private static ProcessInfo startProcess(string path, string args = "") {
            ProcessInfo pi;
            CreateProcess(
                path,
                args,
                IntPtr.Zero,
                IntPtr.Zero,
                false,
                0,
                IntPtr.Zero,
                null,
                IntPtr.Zero,
                out pi
            );
            return pi;
        }

        private static void stopCal()
        {
            Console.WriteLine(@"Stopping: Micros CAL...");
            ProcessInfo pi = startProcess(@"\DOC\McrsCAL\McrsCAL.exe", "/Exit");
            WaitForSingleObject(pi.hProcess, INFINITE);
            Console.WriteLine(@"Micros CAL: Stopped.");
        }

        [DllImport("coredll.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto)]
            static extern bool CreateProcess(
            string lpApplicationName,
            string lpCommandLine,
            IntPtr lpProcessAttributes,
            IntPtr lpThreadAttributes,
            bool bInheritHandles,
            uint dwCreationFlags,
            IntPtr lpEnvironment,
            string lpCurrentDirectory,
            IntPtr lpStartupInfo,
            out ProcessInfo lpProcessInformation
        );

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern Int32 WaitForSingleObject(IntPtr Handle, Int32 Wait);


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct ProcessInfo
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public Int32 ProcessId;
            public Int32 ThreadId;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SecurityAttributes
        {
            public int length;
            public IntPtr lpSecurityDescriptor;
            public bool bInheritHandle;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct StartupInfo
        {
            public uint cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public uint dwX;
            public uint dwY;
            public uint dwXSize;
            public uint dwYSize;
            public uint dwXCountChars;
            public uint dwYCountChars;
            public uint dwFillAttribute;
            public uint dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }
    }
}
