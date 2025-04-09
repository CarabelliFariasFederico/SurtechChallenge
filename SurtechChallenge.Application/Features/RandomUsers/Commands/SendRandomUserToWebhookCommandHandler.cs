using MediatR;
using SurtechChallenge.Application.Interfaces;

namespace SurtechChallenge.Application.Features.RandomUser.Commands;

public class SendRandomUserToWebhookCommandHandler : IRequestHandler<SendRandomUserToWebhookCommand, bool>
{
    private readonly IRandomUserService _randomUserService;

    public SendRandomUserToWebhookCommandHandler(IRandomUserService randomUserService)
    {
        _randomUserService = randomUserService;
    }

    public async Task<bool> Handle(SendRandomUserToWebhookCommand request, CancellationToken cancellationToken)
    {
        var userPayload = await _randomUserService.GetAndMapRandomUserAsync();
        if (userPayload == null) return false;

        await _randomUserService.SendToWebhookAsync(userPayload, request.WebhookId);
        return true;
    }
}
