namespace Degus
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;

    public partial class App : Application
    {

        public App()
        {
            Startup += App_Startup;
        }

        void App_Startup(object sender, StartupEventArgs e)
        {
            var parameterSet = ParameterParser.GetParameterSet(e.Args);
            if(!parameterSet.IsValid)
            {
                // TODO: implement more informative error reporting.
                Console.WriteLine("Invalid parameters");
            }
            else
            {
                switch (parameterSet.Action)
                {
                    case ScriptingAction.ShowGUI:
                        MainWindow wnd = new MainWindow();
                        wnd.Show();
                        break;
                    case ScriptingAction.Script:
                        break;
                    default:
                        Console.WriteLine("Unknown action");
                        break;
                }
            }
        }
    }
}
