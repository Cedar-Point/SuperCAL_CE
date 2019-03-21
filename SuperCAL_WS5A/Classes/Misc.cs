using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System.Reflection;

namespace SuperCAL_CE
{
    class Misc
    {
        private static string PersistentStore = null;
        private static string[] StopCalProcesses = new string[]
        {
            "McrsCAL.exe",
            "SarOpsMM.exe",
            "SarOps.exe",
            "KDSDisplay.exe"
        };
        public static void StartCAL()
        {
            Logger.Log("Starting CAL...");
            Process.Start(GetPersistentStore() + @"\McrsCAL\McrsCAL.exe", "");
            Logger.Good("CAL Started.");
        }
        public static void StopCAL()
        {
            Logger.Log("Stopping CAL...");
            foreach(ProcessCE process in ProcessCE.GetProcesses())
            {
                foreach(string calProcess in StopCalProcesses)
                {
                    if(calProcess.ToLower() == process.processName.ToLower())
                    {
                        Logger.Log(process.processName + ": Killing...");
                        Process.GetProcessById(process.handle.ToInt32()).Kill();
                        Logger.Good(process.processName + ": Killed.");
                        break;
                    }
                }
            }
            Logger.Good("CAL Stopped.");
        }
        public static string GetCurrentDirectory()
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().GetName().CodeBase;
            return Path.GetDirectoryName(assemblyLocation);
        }

        public static bool IsCalStarted()
        {
            bool found = false;
            foreach(ProcessCE process in ProcessCE.GetProcesses())
            {
                if(process.processName.ToLower() == "mcrscal.exe")
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
        public static string GetPersistentStore()
        {
            if (PersistentStore == null)
            {
                Logger.Log("Finding Persistent Store...");
                try
                {
                    RegistryKey CalConfig = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Micros\CAL\Config", false);
                    PersistentStore = (string)CalConfig.GetValue("PersistentStore");
                }
                catch(Exception)
                {
                    Logger.Error(@"Could not find: HKLM\SOFTWARE\Micros\CAL\Config\PersistentStore");
                }
                Logger.Good("Persistent Store Found at: " + PersistentStore);
            }
            return PersistentStore;
        }
    }
}
