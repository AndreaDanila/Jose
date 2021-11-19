using System.Text.Json.Serialization;

namespace TestWebApi.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [JsonPropertyName("sn1")]
        public string Surname1 { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
