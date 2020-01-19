using System;
using System.Text.Json.Serialization;

namespace CarBookingGUI
{
    public class Car
    {
        [JsonPropertyName("ID")]
        public int ID { get; set; }

        [JsonPropertyName("Make")]
        public String Make { get; set; }

        [JsonPropertyName("Model")]
        public String Model { get; set; }
    }
}
