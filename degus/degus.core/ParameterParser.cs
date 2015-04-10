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
                
                if(!Enum.TryParse<ScriptingAction>(actionParameter, ignoreCase: true, result:out scriptingAction))
                {
                    parameterSet.IsValid = false;
                    return parameterSet;
                }
                parameterSet.Action = scriptingAction;
            }
            return parameterSet;
        }
    }
}
