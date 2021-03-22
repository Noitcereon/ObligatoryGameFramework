using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;

namespace _2DTurnBasedGameFramework.Configuration
{
    public class LoadConfig
    {
        private static readonly string ConfigFilePath = Directory.GetCurrentDirectory() + @"\Configuration.xml";
        private static readonly XmlDocument Doc = new XmlDocument();

        public static SourceLevels SourceLevel()
        {
            try
            {
                if (!File.Exists(ConfigFilePath))
                {
                    using (FileStream fs = File.Create(ConfigFilePath))
                    {
                        const string defaultConfiguration = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<Configuration>\r\n\r\n  <!-- DebugLevel determines which logging messages should be logged -->\r\n  <!-- Debug Levels: All, Informational, Warning, Error, Critical, Off -->\r\n  <DebugLevel>All</DebugLevel>\r\n</Configuration>";
                        byte[] configInBytes = Encoding.UTF8.GetBytes(defaultConfiguration);
                        fs.Write(configInBytes);
                    }
                }
                Doc.Load(ConfigFilePath);
                XmlNode debugNode = Doc.DocumentElement?.SelectSingleNode("DebugLevel");
                bool success = Enum.TryParse(debugNode?.InnerText, out SourceLevels level);

                return success ? level : SourceLevels.Error;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
