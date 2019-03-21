using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

namespace SuperCAL_CE
{
    class Wipe
    {
        public static string EGatewayURL = null;
        public static string EGatewayHost = null;

        private static string[] WipeFolders = new string[]
        {
            "CALTemp",
            "PosClient",
            "Micros"
        };
        private static string[] WipeStores = new string[]
        {
            "CF",
            "STORE"
        };
        private static Dictionary<string, object> KeepValues = new Dictionary<string, object> {
            { "PersistentStore", null },
            { "DeviceId", null },
            { "ServiceHostId", null },
            { "ProductType", null },
            { "WSId", null },
            { "HwConfigured", null }
        };
        public static void Do(bool keepCal = false)
        {
            if(keepCal)
            {
                SaveImportantValues();
            }
            WipeMicrosKey();
            ReplaceImportantValues();
            WipeFileStores();
        }

        private static void SaveImportantValues()
        {
            Logger.Log("CAL Config: Saving...");
            RegistryKey CalConfig = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Micros\CAL\Config", false);
            List<string> keepValueNames = new List<string>();
            foreach (KeyValuePair<string, object> keepValue in KeepValues)
            {
                keepValueNames.Add(keepValue.Key);
            }
            foreach (string keepValueName in keepValueNames)
            {
                try
                {
                    Logger.Log(keepValueName + ": Saving from registry...");
                    KeepValues[keepValueName] = CalConfig.GetValue(keepValueName);
                }
                catch(Exception)
                {
                    Logger.Warning(keepValueName + ": Failed to save value.");
                }
            }
            CalConfig.Close();
            Logger.Good("CAL Config: Saved.");
        }

        private static void WipeMicrosKey()
        {
            Logger.Log("Micros Reg: Clearing...");
            RegistryKey MicrosReg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Micros", true);
            foreach(string key in MicrosReg.GetSubKeyNames())
            {
                try
                {
                    Logger.Log(key + ": Clearing...");
                    MicrosReg.DeleteSubKeyTree(key);
                    Logger.Good(key + ": Cleared.");
                }
                catch(Exception)
                {
                    Logger.Warning(key + ": Failed to clear key.");
                }
            }
            Logger.Good("Micros Reg: Cleared.");
            Logger.Log(@"Micros Reg: Creating CAL\Config and writing default values...");
            RegistryKey CalConfig = MicrosReg.CreateSubKey("CAL").CreateSubKey("Config");
            CalConfig.SetValue("ActiveHostIpAddress", EGatewayURL);
            Logger.Log(@"Micros Reg: ActiveHostIpAddress = " + EGatewayURL);
            CalConfig.SetValue("ActiveHost", EGatewayHost);
            Logger.Log(@"Micros Reg: ActiveHost = " + EGatewayHost);
            CalConfig.SetValue("POSType", 101);
            Logger.Log(@"Micros Reg: ActiveHostIpAddress = 101");
            CalConfig.Close();
            MicrosReg.Close();
            Logger.Good("Micros Reg: Done.");
        }

        private static void WipeFileStores()
        {
            foreach(string store in WipeStores)
            {
                foreach(string folder in WipeFolders)
                {
                    string path = @"\" + store + @"\" + folder;
                    if(Directory.Exists(path))
                    {
                        try
                        {
                            Logger.Log(path + ": Deleting...");
                            Directory.Delete(path, true);
                            Logger.Good(path + ": Deleted.");
                        }
                        catch(Exception)
                        {
                            Logger.Error(path + ": Error deleting directory.");
                        }
                    }
                }
            }
        }

        private static void ReplaceImportantValues()
        {
            Logger.Log("CAL Config: Writing saved values...");
            RegistryKey CalConfig = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Micros\CAL\Config", true);
            foreach (KeyValuePair<string, object> regValue in KeepValues)
            {
                try
                {
                    Logger.Log(regValue.Key + ": Writing to registry...");
                    CalConfig.SetValue(regValue.Key, regValue.Value);
                }
                catch (Exception)
                {
                    Logger.Warning(regValue.Key + ": Failed to write value.");
                }
            }
            CalConfig.Close();
            Logger.Good("CAL Config: Done.");
        }
    }
}
