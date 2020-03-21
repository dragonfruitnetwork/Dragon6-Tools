// Dragon6 Tools Copyright 2020 DragonFruit Network. Licensed under the MIT License

using Newtonsoft.Json;

namespace DragonFruit.Six.Tools.Data.Objects
{
    public class CountryInfo
    {
        [JsonProperty("alpha2Code")]
        public string Iso2 { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
