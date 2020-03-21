// Dragon6 Tools Copyright 2020 DragonFruit Network. Licensed under the MIT License

using System.Collections.Generic;
using System.Linq;

namespace DragonFruit.Six.Tools.Helpers
{
    public static class DictionaryCodeDisplay
    {
        public static string ToCodeDisplay(this IEnumerable<KeyValuePair<string, string>> dict)
        {
            var lines = dict.Select(x => $"[\"{x.Key}\"] = \"{x.Value}\"");

            return string.Join(",\n", lines);
        }
    }
}
