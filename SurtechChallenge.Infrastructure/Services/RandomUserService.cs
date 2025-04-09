using SurtechChallenge.Application.Interfaces;
using SurtechChallenge.Domain.Entities;
using System.Net.Http.Json;
using System.Text.Json;

namespace SurtechChallenge.Infrastructure.Services;

public class RandomUserService : IRandomUserService
{
    private readonly HttpClient _httpClient;

    public RandomUserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<RandomUserWebhookPayload?> GetAndMapRandomUserAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<RandomUserApiResponse>("https://randomuser.me/api");
        var user = response?.Results.FirstOrDefault();

        if (user == null) return null;

        return new RandomUserWebhookPayload
        {
            Name = user.Name,
            Login = user.Login
        };
    }

    public async Task SendToWebhookAsync(RandomUserWebhookPayload payload, string webhookId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"https://webhook.site/{webhookId}")
        {
            Content = JsonContent.Create(payload)
        };
        request.Headers.Add("Surtechnology", "6E3F37EF-2DBC-4062-B974-5812DCB0B2AC");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }
}

internal class RandomUserApiResponse
{
    public List<RandomUserData> Results { get; set; } = new();
}

internal class RandomUserData
{
    public Name Name { get; set; } = new();
    public Login Login { get; set; } = new();
}
