namespace SurtechChallenge.Domain.Entities;

public class RandomUserWebhookPayload
{
    public Name Name { get; set; } = new();
    public Login Login { get; set; } = new();
}

public class Name
{
    public string Title { get; set; } = string.Empty;
    public string First { get; set; } = string.Empty;
    public string Last { get; set; } = string.Empty;
}

public class Login
{
    public string Uuid { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public string Md5 { get; set; } = string.Empty;
    public string Sha1 { get; set; } = string.Empty;
    public string Sha256 { get; set; } = string.Empty;
}
