namespace Degus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IScripter
    {
        void WriteScript(string serverName, string databaseName, bool useSingleFile = true, string outputPath = null, bool overwriteFile = true, bool scriptData = false, IEnumerable<TableConfiguration> tableConfigurations = null);
    }
}
