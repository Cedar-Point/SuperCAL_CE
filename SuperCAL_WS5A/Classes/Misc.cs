using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;

namespace SuperCAL_CE
{
    class Misc
    {
        private static string PersistentStore = null;
        public static void StartCAL()
        {
            Logger.Log("Starting CAL...");
            Process.Start(GetPersistentStore() + @"\McrsCAL\McrsCAL.exe", "");
            Logger.Good("CAL Started.");
        }

        public static void StopCAL()
        {
            Logger.Log("Stopping CAL...");
            Process stop = Process.Start(GetPersistentStore() + @"\McrsCAL\McrsCAL.exe", "");
            stop.WaitForExit();
            Logger.Good("CAL Stopped.");
        }

        public static bool IsCalStarted()
        {
            foreach(ProcessCE process in ProcessCE.GetProcesses())
            {
                Logger.Log(process.processName);
            }
            return false;
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
