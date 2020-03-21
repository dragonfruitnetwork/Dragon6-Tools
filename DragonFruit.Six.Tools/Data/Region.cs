// Dragon6 Tools Copyright 2020 DragonFruit Network. Licensed under the MIT License

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using DragonFruit.Common.Data.Services;
using DragonFruit.Six.Tools.Data.Objects;
using Newtonsoft.Json;

namespace DragonFruit.Six.Tools.Data
{
    public static class Region
    {
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        private static readonly IReadOnlyDictionary<string, string> RegionMatchers = new Dictionary<string, string>
        {
            ["Africa"] = "emea",
            ["Europe"] = "emea",

            ["Americas"] = "ncsa",

            ["Asia"] = "apac",
            ["Oceania"] = "apac"
        };

        private static JsonSerializerSettings Settings => new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        public static IEnumerable<KeyValuePair<string, string>> GetRegionInfo()
        {
            using var client = new HttpClient();

            //get the info
            var rawData = WebServices.StreamObject<IEnumerable<CountryInfo>>("https://restcountries.eu/rest/v2/all", client, JsonSerializer.Create(Settings));

            //get dictionary
            return rawData.Where(x => RegionMatchers.Keys.Contains(x.Region))
                          .Select(x => new KeyValuePair<string, string>(x.Iso2, RegionMatchers[x.Region]))
                          .OrderBy(x => x.Value)
                          .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
