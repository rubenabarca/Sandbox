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

        public ParameterSet()
        {
            IsValid = true;
        }
    }
}
