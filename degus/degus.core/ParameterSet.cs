namespace Degus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ParameterSet
    {
        public bool IsValid { get; set; }
        public ScriptingAction Action { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public bool UseSingleFile { get; set; }
        public string OutputPath { get; set; }
        public bool OverwriteFile { get; set; }

        public ParameterSet()
        {
            IsValid = true;
            UseSingleFile = true;
            OverwriteFile = true;
        }
    }
}
