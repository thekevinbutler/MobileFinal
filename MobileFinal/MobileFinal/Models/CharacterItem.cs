using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MobileFinal.Models
{
    public static class CharacterItem 
    {

        public partial class CharacterInfo
        {
            [JsonProperty("lastmodified")]
            public long lastModified { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("realm")]
            public string realm { get; set; }
            [JsonProperty("battlegroup")]
            public string battlegroup { get; set; }
            [JsonProperty("class")]
            public int wclass { get; set; }
            [JsonProperty("race")]
            public int race { get; set; }
            [JsonProperty("gender")]
            public int gender { get; set; }
            [JsonProperty("level")]
            public int level { get; set; }
            [JsonProperty("achievementPoints")]
            public int achievementPoints { get; set; }
            [JsonProperty("thumbnail")]
            public string thumbnail { get; set; }
            [JsonProperty("calcClass")]
            public string calcClass { get; set; }
            [JsonProperty("faction")]
            public int faction { get; set; }
            [JsonProperty("totalHonorableKills")]
            public int totalHonorableKills { get; set; }
        }

        public partial class CharacterInfo
        {
            public static CharacterInfo FromJson(string json) => JsonConvert.DeserializeObject<CharacterInfo>(json, Converter.Settings);
        }

        public static string ToJson(this CharacterInfo self) => JsonConvert.SerializeObject(self, Converter.Settings);

        public class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };
        }



    }
}
