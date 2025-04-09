using MediatR;

namespace SurtechChallenge.Application.Features.RandomUser.Commands;

public class SendRandomUserToWebhookCommand : IRequest<bool>
{
    public string WebhookId { get; set; } = string.Empty;
}
