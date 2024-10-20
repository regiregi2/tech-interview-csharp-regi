using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Vehicle
    {
        [JsonPropertyName("price")]
        public float Price { get; set; }

        [JsonPropertyName("make")]
        public string Make { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("trim")]
        public string Trim { get; set; }

        [JsonPropertyName("colour")]
        public string Colour { get; set; }

        [JsonPropertyName("co2_level")]
        public float Co2Level { get; set; }

        [JsonPropertyName("transmission")]
        public string Transmission { get; set; }

        [JsonPropertyName("fuel_type")]
        public string FuelType { get; set; }

        [JsonPropertyName("engine_size")]
        public float EngineSize { get; set; }

        [JsonPropertyName("date_first_reg")]
        public string DateFirstReg { get; set; }

        [JsonPropertyName("mileage")]
        public float Mileage { get; set; }
    }
}
