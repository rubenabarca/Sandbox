namespace Degus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [Serializable]
    public class TableConfiguration
    {
        [XmlAttribute]
        public string TableName { get; set; }
        [XmlAttribute]
        public bool ScriptData { get; set; }
    }

    [Serializable]
    public class ScriptingConfiguration
    {
        [NonSerialized]
        public bool IsValid { get; set; }
        [NonSerialized]
        public string ConfigFile { get; set; }
        [XmlAttribute]
        public ScriptingAction Action { get; set; }
        [XmlAttribute]
        public string ServerName { get; set; }
        [XmlAttribute]
        public string DatabaseName { get; set; }
        [XmlAttribute]
        public bool UseSingleFile { get; set; }
        [XmlAttribute]
        public string OutputPath { get; set; }
        [XmlAttribute]
        public bool OverwriteFile { get; set; }
        [XmlAttribute]
        public bool ScriptData { get; set; }
        [XmlArray]
        public List<TableConfiguration> TableConfigurations { get; set; }

        public ScriptingConfiguration()
        {
            IsValid = true;
            UseSingleFile = true;
            OverwriteFile = true;
            TableConfigurations = new List<TableConfiguration>();
        }
    }
}
