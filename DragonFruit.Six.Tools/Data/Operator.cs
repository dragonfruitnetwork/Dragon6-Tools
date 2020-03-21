// Dragon6 Tools Copyright 2020 DragonFruit Network. Licensed under the MIT License

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using DragonFruit.Common.Data.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Tools.Data
{
    public static class Operator
    {
        private const string UbiOperatorData = "https://game-rainbow6.ubi.com/assets/data/operators.9d15c77e.json";
        private const string UbiStringsData = "https://game-rainbow6.ubi.com/assets/locales/locale.en-us.cdf7a32a.json";
        private const string Dragon6IconUrl = "https://d6static.dragonfruit.network/ops/{0}.png";

        public static JArray GetOperatorData()
        {
            using var client = new HttpClient();
            var serializer = JsonSerializer.CreateDefault();

            var oasisText = WebServices.StreamObject<Dictionary<string, string>>(UbiStringsData, client, serializer);
            var operatorData = WebServices.StreamObject<Dictionary<string, JObject>>(UbiOperatorData, client, serializer).Select(x => x.Value);

            var result = new JArray();

            foreach (var ubiInfo in operatorData)
            {
                try
                {
                    //name must be converted to lowercase otherwise the ToTitleCase function won't work
                    var name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(oasisText[(string)ubiInfo["name"]["oasisId"]].ToLowerInvariant());

                    var operatorInfo = new JObject
                    {
                        ["name"] = name,
                        ["img"] = string.Format(Dragon6IconUrl, name),
                        ["index"] = ubiInfo["index"],
                        ["actn"] = ubiInfo["uniqueStatistic"]["pvp"]["statisticId"],
                        ["phrase"] = oasisText[(string)ubiInfo["uniqueStatistic"]["pvp"]["label"]["oasisId"]],
                        ["org"] = oasisText[(string)ubiInfo["ctu"]["oasisId"]],
                        ["type"] = (string)ubiInfo["category"] == "atk" ? 1 : 2,
                        ["sub"] = "Pathfinders"
                    };

                    result.Add(operatorInfo);
                }
                catch
                {
                    //ignore for now
                }
            }

            return result;
        }
    }
}
