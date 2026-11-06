using System.Text.Json.Serialization;

namespace WestcoastEducation.Core.Models;

public abstract class Person
{
    // Id från RestDb (_id). Skickas inte med för nya personer, RestDb skapar det
    [JsonPropertyName("_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string PersonalNumber { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string ZipCode { get; set; }  = string.Empty;
    public string City { get; set; } = string.Empty;
}