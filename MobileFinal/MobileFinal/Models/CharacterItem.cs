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
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("realm")]
            public string Realm { get; set; }

            [JsonProperty("race")]
            public String Race { get; set; }

            [JsonProperty("achievementPoints")]
            public String AchievementPoints { get; set; }

            [JsonProperty("thumbnail")]
            public ImageSource Thumbnail { get; set; }


            [JsonProperty("faction")]
            public string Faction { get; set; }

            [JsonProperty("totalHonorableKills")]
            public String TotalHonorableKills { get; set; }
        }

        public partial class CharcterInfo
        {
            public static CharcterInfo FromJson(string json) => JsonConvert.DeserializeObject<CharcterInfo>(json, Converter.Settings);
        }

        public static string ToJson(this CharcterInfo self) => JsonConvert.SerializeObject(self, Converter.Settings);

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
