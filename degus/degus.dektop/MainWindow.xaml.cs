namespace Degus
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Sdk.Sfc;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var databaseName = "ferret-cms-dev";
            var server = new Server(@".\SQLExpress");

            var database = server.Databases[databaseName];

            var scripter = new Scripter(server);
            scripter.Options.IncludeIfNotExists = true;
            scripter.Options.IncludeHeaders = false;

            var tableUrnArray = (from Table table in database.Tables
                                 select table.Urn).ToArray();
            var scriptCollection = scripter.Script(tableUrnArray);

            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            foreach (var scriptString in scriptCollection)
            {
                ScriptTextBox.AppendText(scriptString);
                ScriptTextBox.AppendText(System.Environment.NewLine);
            }
        }
    }
}
