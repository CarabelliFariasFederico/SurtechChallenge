using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Application.Interfaces;

public interface IRandomUserService
{
    Task<RandomUserWebhookPayload?> GetAndMapRandomUserAsync();
    Task SendToWebhookAsync(RandomUserWebhookPayload payload, string webhookId);
}
