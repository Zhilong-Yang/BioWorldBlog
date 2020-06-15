using System;
using System.Collections.Generic;
using System.Text;

namespace BioWorld.Application.Core
{
    public static class Utils
    {
        private static readonly Tuple<string, string>[] TagNormalizeSourceTable =
        {
            Tuple.Create(".", "dot"),
            Tuple.Create("#", "sharp"),
            Tuple.Create(" ", "-")
        };

        private static string ReplaceWithStringBuilder(string value, IEnumerable<Tuple<string, string>> toReplace)
        {
            var result = new StringBuilder(value);
            foreach (var (item1, item2) in toReplace)
            {
                result.Replace(item1, item2);
            }
            return result.ToString();
        }

        public static string NormalizeTagName(string orgTagName)
        {
            return ReplaceWithStringBuilder(orgTagName, TagNormalizeSourceTable).ToLower();
        }

    }
}
