using System;
using System.Text.Json.Serialization;

namespace CarBookingGUI
{
    public class Car
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("make")]
        public String Make { get; set; }

        [JsonPropertyName("model")]
        public String Model { get; set; }
    }

    public class Booking
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("carID")]
        public int CarID { get; set; }

        [JsonPropertyName("customerID")]
        public int CustomerID { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}
