using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BotFrameworkToken.Models
{
    public partial class DirectLineAuthenticationResponse
    {
        [JsonProperty("conversationId")]
        public string ConversationId { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("streamUrl")]
        public Uri StreamUrl { get; set; }
    }

    public partial class DirectLineAuthenticationResponse
    {
        public static DirectLineAuthenticationResponse FromJson(string json) => JsonConvert.DeserializeObject<DirectLineAuthenticationResponse>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this DirectLineAuthenticationResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
