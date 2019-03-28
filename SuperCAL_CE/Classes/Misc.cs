using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace SuperCAL_CE
{
    class Misc
    {
        public static string[] McrsCalProcesses = null;
        public static string[] McrsCalPaths = null;
        public static void StartCAL()
        {
            Logger.Log("CAL: Starting...");
            bool calFound = false;
            foreach(string McrsCalPath in McrsCalPaths)
            {
                if (File.Exists(McrsCalPath))
                {
                    Logger.Log(McrsCalPath + ": Starting...");
                    Process.Start(McrsCalPath, "");
                    calFound = true;
                }
            }
            if(calFound)
            {
                Logger.Good("CAL: Started.");
            }
            else
            {
                Logger.Error("Could not find McrsCAL! Make sure the path to McrsCAL.exe is specified in the SuperCAL_CE.xml");
            }
        }
        public static void StopCAL()
        {
            Logger.Log("Stopping CAL...");
            foreach(ProcessCE process in ProcessCE.GetProcesses())
            {
                foreach(string calProcess in McrsCalProcesses)
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
    }
}
