using Realm.Wisher.Infrastructure.Converters;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Realm.Wisher.Core.Entities
{
    public class Employee
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [JsonPropertyName("dateOfBirth")]
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime DateOfBirth { get; set; }


        [JsonPropertyName("employmentStartDate")]
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime EmploymentStartDate { get; set; }


        [JsonPropertyName("employmentEndDate")]
        [JsonConverter(typeof(NullableDateTimeJsonConverter))]
        public DateTime? EmploymentEndDate { get; set; }


        [JsonPropertyName("lastNotification")]
        [JsonConverter(typeof(NullableDateTimeJsonConverter))]
        public DateTime? LastNotification { get; set; }


        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
