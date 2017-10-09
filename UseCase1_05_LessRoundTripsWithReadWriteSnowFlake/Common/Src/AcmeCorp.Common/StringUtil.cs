using System;
using System.Collections.Generic;

namespace AcmeCorp.Common
{
    public static class StringUtil
    {
        public static string ToSingleQuotedString(this string value) => value.SurroundWith("'");
        public static string ToDoubleQuotedString(this string value) => value.SurroundWith("\"");

        public static string SurroundWith(this string value, string surround) =>
            !(value != null && value.StartsWith(surround) && value.EndsWith(surround)) ? $"{surround}{value}{surround}" : value;


        public static string ToCSV(this IEnumerable<string> value) => string.Join("," , value);

        public static bool IsBlank(this object obj) => obj == null || obj == DBNull.Value || string.IsNullOrWhiteSpace(obj.ToString());
    }
}
