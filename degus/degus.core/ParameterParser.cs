namespace Degus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ParameterParser
    {
        public static ParameterSet GetParameterSet(string[] parameterStringArray)
        {
            var parameterSet = new ParameterSet();
            if (parameterStringArray.Length > 0)
            {
                var actionParameter = parameterStringArray[0];
                ScriptingAction scriptingAction;

                if (!Enum.TryParse<ScriptingAction>(actionParameter, ignoreCase: true, result: out scriptingAction))
                {
                    parameterSet.IsValid = false;
                    return parameterSet;
                }
                parameterSet.Action = scriptingAction;
                switch (parameterSet.Action)
                {
                    case ScriptingAction.ShowGUI:
                        break;
                    case ScriptingAction.Script:
                        parameterSet.ServerName = GetParameterValue(parameterStringArray, "ServerName");
                        parameterSet.DatabaseName = GetParameterValue(parameterStringArray, "DatabaseName");
                        parameterSet.IsValid = !string.IsNullOrEmpty(parameterSet.ServerName) && !string.IsNullOrEmpty(parameterSet.DatabaseName);
                        break;
                    default:
                        break;
                }
            }
            return parameterSet;
        }

        private static string GetParameterValue(string[] parameterStringArray, string parameterName)
        {
            foreach (var parameterString in parameterStringArray)
            {
                if (parameterString.ToLower().Contains(string.Format("{0}=", parameterName.ToLower())))
                {
                    var stringValues = parameterString.Split('=');
                    if (stringValues.Length == 2)
                    {// if we have two values then the parameter is syntax is valid (i.e.: serverName=MyServer).
                        return stringValues[1]; //The value of the parameter is to the right of the '=' sign.
                    }
                }
            }
            return null; //the parameter with this name was not found.
        }
    }
}
