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
    public static class NewsItem
    {
        public partial class NewsArticle
        {
            [JsonProperty("status")]
            public String status { get; set; }

            [JsonProperty("article")]
            public List<Articles> Article { get; set; }
        }

        
        public partial class Articles
        {

            [JsonProperty("source")]
            public Source Source { get; set; }

            [JsonProperty("author")]
            public string Author { get; set; }

            [JsonProperty("title")]
            public String Title { get; set; }

            [JsonProperty("description")]
            public String Description { get; set; }

            [JsonProperty("url")]
            public Uri Url { get; set; }

            [JsonProperty("urlToImage")]
            public ImageSource UrlToImage { get; set; }


            [JsonProperty("publishedAt")]
            public DateTime publishedAt { get; set; }


        }

        public partial class Source
        {
            [JsonProperty("id")]
            public String Id { get; set; }

            [JsonProperty("name")]
            public String Name { get; set; }
        }


        public partial class NewsArticle
        {
            public static NewsArticle FromJson(string json) => JsonConvert.DeserializeObject<NewsArticle>(json, Converter.Settings);
        }

        public static string ToJson(this NewsArticle self) => JsonConvert.SerializeObject(self, Converter.Settings);

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
