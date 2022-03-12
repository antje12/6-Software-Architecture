using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TA3.Models
{
    public class ProductJson
    {
        public string name { get; set; }

        public float price { get; set; }

        // Here we're using this so we can use another variable name that the JSON property that's used
        // That way, the structure of our data doesn't have to define the structure of our code
        [JsonPropertyName("Location")] public string? aisle { get; set; }

        // Method to get the data in a JSON format using serialization
        public override string ToString() => JsonSerializer.Serialize<ProductJson>(this);
    }
}