using System;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace _2DTurnBasedGameFramework.Configuration
{
    public class LoadConfig
    {
        private static readonly string ConfigFilePath = Directory.GetCurrentDirectory() + @"\Configuration.xml";
        private static readonly XmlDocument Doc = new XmlDocument();

        public static SourceLevels SourceLevel()
        {
            Doc.Load(ConfigFilePath);
            XmlNode debugNode = Doc.DocumentElement?.SelectSingleNode("DebugLevel");
            bool success = Enum.TryParse(debugNode?.InnerText, out SourceLevels level);

            return success ? level : SourceLevels.Error;
        }
    }
}
