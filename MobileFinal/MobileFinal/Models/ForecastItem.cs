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
    public static class ForecastItem
    {
        public class City
        {
            [JsonProperty("id")]
            public int id { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
        }

        public class Coord
        {
            [JsonProperty("lon")]
            public double lon { get; set; }
            [JsonProperty("lat")]
            public double lat { get; set; }
        }

        public class Main
        {
            [JsonProperty("temp")]
            public double temp { get; set; }
            [JsonProperty("temp_min")]
            public double temp_min { get; set; }
            [JsonProperty("temp_max")]
            public double temp_max { get; set; }
            [JsonProperty("pressure")]
            public double pressure { get; set; }
            [JsonProperty("sea_level")]
            public double sea_level { get; set; }
            [JsonProperty("grnd_level")]
            public double grnd_level { get; set; }
            [JsonProperty("humidity")]
            public int humidity { get; set; }
            [JsonProperty("temp_kf")]
            public double temp_kf { get; set; }
        }

        public class Weather
        {
            [JsonProperty("id")]
            public int id { get; set; }
            [JsonProperty("main")]
            public string main { get; set; }
            [JsonProperty("description")]
            public string description { get; set; }
            [JsonProperty("icon")]
            public string icon { get; set; }
        }

        public class Clouds
        {
            [JsonProperty("all")]
            public int all { get; set; }
        }

        public class Wind
        {
            [JsonProperty("speed")]
            public double speed { get; set; }
            [JsonProperty("deg")]
            public double deg { get; set; }
        }

        public class Sys
        {
            [JsonProperty("pod")]
            public string pod { get; set; }
        }

        public class List
        {
            [JsonProperty("dt")]
            public int dt { get; set; }
            [JsonProperty("main")]
            public Main main { get; set; }
            [JsonProperty("weather")]
            public List<Weather> weather { get; set; }
            [JsonProperty("clouds")]
            public Clouds clouds { get; set; }
            [JsonProperty("wind")]
            public Wind wind { get; set; }
            [JsonProperty("sys")]
            public Sys sys { get; set; }
            [JsonProperty("dt_txt")]
            public string dt_txt { get; set; }
        }

        public partial class ForecastInfo
        {
            [JsonProperty("city")]
            public City city { get; set; }
            [JsonProperty("coord")]
            public Coord coord { get; set; }
            [JsonProperty("country")]
            public string country { get; set; }
            [JsonProperty("cod")]
            public string cod { get; set; }
            [JsonProperty("message")]
            public double message { get; set; }
            [JsonProperty("cnt")]
            public int cnt { get; set; }
            [JsonProperty("list")]
            public List<List> list { get; set; }
        }


        public partial class ForecastInfo
        {
            public static ForecastInfo FromJson(string json) => JsonConvert.DeserializeObject<ForecastInfo>(json, Converter.Settings);
        }

        public static string ToJson(this ForecastInfo self) => JsonConvert.SerializeObject(self, Converter.Settings);

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
