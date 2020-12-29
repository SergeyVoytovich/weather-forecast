using System;
using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto
{
    /// <summary>
    /// Date time converter
    /// </summary>
    /// <remarks>Converted UNIX date to DateTime object</remarks>
    public class UnixDateTimeConverter : JsonConverter
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.Value is long value && value > 0)
            {
                return Epoch.AddSeconds(value);
            }

            return DateTime.MinValue;
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}