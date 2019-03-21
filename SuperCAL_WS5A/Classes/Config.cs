using System.Xml.Linq;

namespace SuperCAL_CE
{
    class Config
    {
        public static void GenerateConfig()
        {
            new XDocument(new XElement("SuperCAL_CE",
                new XElement("EGatewayURL", "http://simphony:8080/EGateway/EGateway.asmx"),
                new XElement("EGatewayHostName", "simphony")
            )).Save(Misc.GetCurrentDirectory() + @"\SuperCAL_CE.xml");
        }
        public static void ReadConfig()
        {
            XElement root = XDocument.Load(Misc.GetCurrentDirectory() + @"\SuperCAL_CE.xml").Root;
            Wipe.EGatewayURL = root.Element("EGatewayURL").Value;
            Wipe.EGatewayHost = root.Element("EGatewayHostName").Value;
        }
    }
}