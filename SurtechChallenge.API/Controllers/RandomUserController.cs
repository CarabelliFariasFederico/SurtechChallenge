using MediatR;
using Microsoft.AspNetCore.Mvc;
using SurtechChallenge.Application.Features.RandomUser.Commands;

namespace SurtechChallenge.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RandomUserController : ControllerBase
{
    private readonly IMediator _mediator;

    public RandomUserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{webhookId}")]
    public async Task<IActionResult> SendToWebhook(string webhookId)
    {
        var result = await _mediator.Send(new SendRandomUserToWebhookCommand { WebhookId = webhookId });

        if (!result)
            return BadRequest("Failed to retrieve random user");

        return Ok("Random user sent to webhook successfully");
    }
}
