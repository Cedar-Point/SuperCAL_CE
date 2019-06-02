using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace SuperCAL_CE
{
    class Config
    {
        private static void GenerateConfig()
        {
            Logger.Good("SuperCAL_CE.xml: Created.");
            new XDocument(new XElement("SuperCAL_CE",
                new XElement("EGatewayURL", "http://simphony:8080/EGateway/EGateway.asmx"),
                new XElement("EGatewayHostName", "simphony"),
                new XElement("McrsCalPaths",
                    new XElement("McrsCalPath", @"\DOC\McrsCAL\McrsCAL.exe"),
                    new XElement("McrsCalPath", @"\BOOT\McrsCAL\McrsCAL.exe")
                ),
                new XElement("McrsCalProcesses",
                    new XElement("McrsCalProcess", "McrsCAL.exe"),
                    new XElement("McrsCalProcess", "SarOps.exe"),
                    new XElement("McrsCalProcess", "SarOpsMM.exe"),
                    new XElement("McrsCalProcess", "KDSDisplay.exe")
                ),
                new XElement("WipePaths",
                    new XElement("WipePath", @"\CF\CALTemp"),
                    new XElement("WipePath", @"\CF\PosClient"),
                    new XElement("WipePath", @"\CF\Micros"),
                    new XElement("WipePath", @"\STORE\CALTemp"),
                    new XElement("WipePath", @"\STORE\PosClient"),
                    new XElement("WipePath", @"\STORE\Micros")
                ),
                new XElement("UnlockMessage", "Enter Unlock PIN"),
                new XElement("UnlockPIN", "1234")
            )).Save(Misc.GetCurrentDirectory() + @"\SuperCAL_CE.xml");
        }
        public static void ReadConfig()
        {
            if (!File.Exists(Misc.GetCurrentDirectory() + @"\SuperCAL_CE.xml"))
            {
                GenerateConfig();
            }
            try
            {
                XElement root = XDocument.Load(Misc.GetCurrentDirectory() + @"\SuperCAL_CE.xml").Root;
                Wipe.EGatewayURL = root.Element("EGatewayURL").Value;
                Wipe.EGatewayHost = root.Element("EGatewayHostName").Value;
                Pin.UnlockMessage = root.Element("UnlockMessage").Value;
                Pin.UnlockPin = root.Element("UnlockPIN").Value;
                List<string> McrsCalPaths = new List<string>();
                foreach (XElement path in root.Element("McrsCalPaths").Elements("McrsCalPath"))
                {
                    McrsCalPaths.Add(path.Value);
                }
                Misc.McrsCalPaths = McrsCalPaths.ToArray();
                List<string> WipePaths = new List<string>();
                foreach (XElement path in root.Element("WipePaths").Elements("WipePath"))
                {
                    WipePaths.Add(path.Value);
                }
                Wipe.WipePaths = WipePaths.ToArray();
                List<string> McrsCalProcesses = new List<string>();
                foreach (XElement process in root.Element("McrsCalProcesses").Elements("McrsCalProcess"))
                {
                    McrsCalProcesses.Add(process.Value);
                }
                Misc.McrsCalProcesses = McrsCalProcesses.ToArray();
            }
            catch(Exception)
            {
                ReadConfig();
            }
        }   
    }
}