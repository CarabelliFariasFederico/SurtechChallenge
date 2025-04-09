namespace SurtechChallenge.Application.DTOs;

public class ApiObjectDto
{
    public string Name { get; set; } = string.Empty;
    public Dictionary<string, object> Data { get; set; } = new();
}

