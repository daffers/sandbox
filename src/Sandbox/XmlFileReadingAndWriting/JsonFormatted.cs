using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XmlFileReadingAndWriting
{

    public class Rootobject
    {
        [JsonProperty(PropertyName = "languageLocaleMappings")]
        public Languagelocalemapping[] LanguageLocaleMappings { get; set; }
    }

    public class Languagelocalemapping
    {
        [JsonProperty(PropertyName = "iso6391LanguageCode")]
        public string Iso6391LanguageCode { get; set; }

        [JsonProperty(PropertyName = "defaultLocale")]
        [JsonConverter(typeof(CultureInfoConverter))]
        public CultureInfo DefaultLocale { get; set; }

        [JsonConverter(typeof(CultureInfoArrayConverter))]
        [JsonProperty(PropertyName = "supportedLocales")]
        public CultureInfo[] SupportedLocales { get; set; }
    }

    public class Supportedlocale
    {
        public string locale { get; set; }
    }

    public class CultureInfoConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new CultureInfo((string)reader.Value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (CultureInfo);
        }
    }

    public class CultureInfoArrayConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray supportedLocales = JArray.Load(reader);
            return supportedLocales.Select(item => new CultureInfo(item["locale"].ToString())).ToArray();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(CultureInfo[]);
        }
    }
}
