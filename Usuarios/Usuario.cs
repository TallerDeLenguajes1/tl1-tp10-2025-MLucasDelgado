using System.Text.Json.Serialization;

namespace usuarios
{
    public class Usuario
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }
        
        [JsonPropertyName("suite")]
        public string Suite { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; }
    }
}