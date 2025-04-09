namespace SurtechChallenge.Domain.Entities;

public class ApiObject
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Dictionary<string, object> Data { get; set; } = new();
}
