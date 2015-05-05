namespace Agouti.Web
{
    using System.Collections.Generic;

    public static class UmbracoExtensions
    {
        public static IEnumerable<string> GetDropDownDataTypeValues(int dataTypeId)
        {
            var dataTypeValues = umbraco.library.GetPreValues(dataTypeId);
            var dataTypeValuesEnumerator = dataTypeValues.GetEnumerator();
            while (dataTypeValues.MoveNext())
            {
                dynamic dataTypeItem = dataTypeValues.Current;
                yield return dataTypeItem.Value;
            }
        }
    }
}