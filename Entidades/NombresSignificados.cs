namespace Entidades
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class NombresSignificados
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("significado")]
        public string Significado { get; set; }

        [JsonProperty("idGenero")]
        public long IdGenero { get; set; }


    }

    public partial class NombresSignificados
    {
        public static List<NombresSignificados> FromJson(string json) => JsonConvert.DeserializeObject<List<NombresSignificados>>(json, Entidades.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this NombresSignificados self) => JsonConvert.SerializeObject(self, Entidades.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
