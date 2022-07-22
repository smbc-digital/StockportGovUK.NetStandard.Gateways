using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StockportGovUK.NetStandard.Gateways.JsonConverters
{
    public class DateTimeConverters
    {
        private const string frenchCanadaLocale = "yyyy-MM-dd HH:mm:ss";

        public class DateTimeJsonConverterFrenchCanada : JsonConverter<DateTime>
        {
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
                    DateTime.ParseExact(reader.GetString(), frenchCanadaLocale, CultureInfo.InvariantCulture);

            public override void Write(Utf8JsonWriter writer, DateTime dateTimeValue, JsonSerializerOptions options) =>
                    writer.WriteStringValue(dateTimeValue.ToString(frenchCanadaLocale, CultureInfo.InvariantCulture));
        }
    }
}
