namespace Degus
{
    using Microsoft.SqlServer.Management.Sdk.Sfc;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SqlServer2012Scripter : IScripter
    {
        public void WriteScript(string serverName, string databaseName, bool useSingleFile = true, string outputPath = null, bool overwriteFile = true, bool scriptData = false, IEnumerable<TableConfiguration> tableConfigurations = null)
        {
            var server = new Server(serverName);

            var database = server.Databases[databaseName];

            var scripter = new Scripter(server);
            scripter.Options.IncludeIfNotExists = true;
            scripter.Options.IncludeHeaders = false;
            scripter.Options.ScriptData = scriptData;

            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var defaultOutputPath = Path.Combine(appDataFolder, @"degus\script");
            if (outputPath == null)
            {
                outputPath = defaultOutputPath;
            }

            StreamWriter scriptTextWriter = null;

            if (useSingleFile)
            {
                if (overwriteFile && File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }
                scriptTextWriter = new StreamWriter(outputPath);
            }

            foreach (Table table in database.Tables)
            {
                if (tableConfigurations != null)
                {
                    var currentTableConfiguration = (from tableConfiguration in tableConfigurations
                                                     where tableConfiguration.TableName == table.Name
                                                     select tableConfiguration).FirstOrDefault();
                    scripter.Options.ScriptData = currentTableConfiguration == null ? scriptData : currentTableConfiguration.ScriptData;
                }
                var scriptCollection = scripter.EnumScript(new Urn[] { table.Urn });
                if (!useSingleFile)
                {
                    var outputFile = Path.Combine(outputPath, string.Format("{0}.{1}.{2}.sql", table.Schema, table.Name, "Table"));
                    if (overwriteFile && File.Exists(outputFile))
                    {
                        File.Delete(outputFile);
                    }
                    scriptTextWriter = new StreamWriter(outputFile);
                }
                foreach (var scriptString in scriptCollection)
                {
                    scriptTextWriter.WriteLine(scriptString);
                }
                if (!useSingleFile)
                {
                    scriptTextWriter.Close();
                }
            }

            scripter.Options.ScriptData = false;
            foreach (View view in database.Views)
            {
                var scriptCollection = scripter.EnumScript(new Urn[] { view.Urn });
                if (!useSingleFile)
                {
                    var outputFile = Path.Combine(outputPath, string.Format("{0}.{1}.{2}.sql", view.Schema, view.Name, "View"));
                    if (overwriteFile && File.Exists(outputFile))
                    {
                        File.Delete(outputFile);
                    }
                    scriptTextWriter = new StreamWriter(outputFile);
                }
                foreach (var scriptString in scriptCollection)
                {
                    scriptTextWriter.WriteLine(scriptString);
                }
                if (!useSingleFile)
                {
                    scriptTextWriter.Close();
                }
            }

            if (useSingleFile)
            {
                scriptTextWriter.Close();
            }

        }
    }
}
