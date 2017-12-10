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
    public static class PokemonItem
    {


        public partial class Ability2
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class Ability
        {
            [JsonProperty("is_hidden")]
            public bool is_hidden { get; set; }
            [JsonProperty("slot")]
            public int slot { get; set; }
            [JsonProperty("ability")]
            public Ability2 ability { get; set; }
        }

        public partial class Form
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class Version
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class GameIndice
        {
            [JsonProperty("game_index")]
            public int game_index { get; set; }
            [JsonProperty("version")]
            public Version version { get; set; }
        }

        public partial class Item
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class Version2
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class VersionDetail
        {
            [JsonProperty("rarity")]
            public int rarity { get; set; }
            [JsonProperty("version")]
            public Version2 version { get; set; }
        }

        public partial class HeldItem
        {
            [JsonProperty("item")]
            public Item item { get; set; }
            [JsonProperty("version_details")]
            public List<VersionDetail> version_details { get; set; }
        }

        public partial class LocationArea
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class ConditionValue
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class Method
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class EncounterDetail
        {
            [JsonProperty("min_level")]
            public int min_level { get; set; }
            [JsonProperty("max_level")]
            public int max_level { get; set; }
            [JsonProperty("condition_values")]
            public List<ConditionValue> condition_values { get; set; }
            [JsonProperty("chance")]
            public int chance { get; set; }
            [JsonProperty("method")]
            public Method method { get; set; }
        }

        public partial class Version3
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class VersionDetail2
        {
            [JsonProperty("max_chance")]
            public int max_chance { get; set; }
            [JsonProperty("encounter_details")]
            public List<EncounterDetail> encounter_details { get; set; }
            [JsonProperty("version")]
            public Version3 version { get; set; }
        }

        public partial class LocationAreaEncounter
        {
            [JsonProperty("location_area")]
            public LocationArea location_area { get; set; }
            [JsonProperty("version_details")]
            public List<VersionDetail2> version_details { get; set; }
        }

        public partial class Move2
        {
            [JsonProperty("move")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class VersionGroup
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class MoveLearnMethod
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class VersionGroupDetail
        {
            [JsonProperty("level_learned_at")]
            public int level_learned_at { get; set; }
            [JsonProperty("version_group")]
            public VersionGroup version_group { get; set; }
            [JsonProperty("move_learn_method")]
            public MoveLearnMethod move_learn_method { get; set; }
        }

        public partial class Move
        {
            [JsonProperty("move")]
            public Move2 move { get; set; }
            [JsonProperty("version_group_details")]
            public List<VersionGroupDetail> version_group_details { get; set; }
        }

        public partial class Species
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class Sprites
        {
            [JsonProperty("back_femal")]
            public string back_female { get; set; }
            [JsonProperty("back_shiny_femal")]
            public string back_shiny_female { get; set; }
            [JsonProperty("back_default")]
            public string back_default { get; set; }
            [JsonProperty("front_female")]
            public string front_female { get; set; }
            [JsonProperty("front_shiny_female")]
            public string front_shiny_female { get; set; }
            [JsonProperty("back_shiny")]
            public string back_shiny { get; set; }
            [JsonProperty("front_default")]
            public string front_default { get; set; }
            [JsonProperty("front_shiny")]
            public string front_shiny { get; set; }
        }

        public partial class Stat2
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class Stat
        {
            [JsonProperty("base_stat")]
            public int base_stat { get; set; }
            [JsonProperty("effort")]
            public int effort { get; set; }
            [JsonProperty("stat")]
            public Stat2 stat { get; set; }
        }

        public partial class Type2
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public partial class Type
        {
            [JsonProperty("slot")]
            public int slot { get; set; }
            [JsonProperty("type")]
            public Type2 type { get; set; }
        }

        public partial class Pokemon
        {
            [JsonProperty("id")]
            public int id { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("base_experience")]
            public int base_experience { get; set; }
            [JsonProperty("height")]
            public int height { get; set; }
            [JsonProperty("is_default")]
            public bool is_default { get; set; }
            [JsonProperty("order")]
            public int order { get; set; }
            [JsonProperty("weight")]
            public int weight { get; set; }
            [JsonProperty("abilities")]
            public List<Ability> abilities { get; set; }
            [JsonProperty("forms")]
            public List<Form> forms { get; set; }
            [JsonProperty("game_indices")]
            public List<GameIndice> game_indices { get; set; }
            [JsonProperty("held_items")]
            public List<HeldItem> held_items { get; set; }
           // [JsonProperty("location_area_encounters")]
           // public List<LocationAreaEncounter> location_area_encounters { get; set; }
            [JsonProperty("moves")]
            public List<Move> moves { get; set; }
            [JsonProperty("species")]
            public Species species { get; set; }
            [JsonProperty("sprites")]
            public Sprites sprites { get; set; }
            [JsonProperty("stats")]
            public List<Stat> stats { get; set; }
            [JsonProperty("types")]
            public List<Type> types { get; set; }
        }



        public partial class Pokemon
        {
            public static Pokemon FromJson(string json) => JsonConvert.DeserializeObject<Pokemon>(json, Converter.Settings);
        }

        public static string ToJson(this Pokemon self) => JsonConvert.SerializeObject(self, Converter.Settings);

        public partial class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };
        }



    }
}
