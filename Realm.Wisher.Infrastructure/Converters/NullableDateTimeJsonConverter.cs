using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace Realm.Wisher.Infrastructure.Converters
{
    public class NullableDateTimeJsonConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime?));
            return reader.GetString() == "" ? null : reader.GetDateTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (!value.HasValue)
            {
                writer.WriteStringValue("");
            }
            else
            {
                writer.WriteStringValue(value.Value);
            }
        }
    }
}
