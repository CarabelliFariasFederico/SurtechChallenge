using FluentAssertions;
using Moq;
using SurtechChallenge.Application.Features.RandomUser.Commands;
using SurtechChallenge.Application.Interfaces;
using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Tests.Features.RandomUser.Commands;

public class SendRandomUserToWebhookCommandHandlerTests
{
    [Fact]
    public async Task Handle_Should_Send_RandomUser_To_Webhook_And_Return_True()
    {
        var payload = new RandomUserWebhookPayload
        {
            Name = new Name { Title = "Mr", First = "John", Last = "Doe" },
            Login = new Login { Username = "johndoe" }
        };

        var mockService = new Mock<IRandomUserService>();
        mockService.Setup(s => s.GetAndMapRandomUserAsync())
                   .ReturnsAsync(payload);
        mockService.Setup(s => s.SendToWebhookAsync(payload, It.IsAny<string>()))
                   .Returns(Task.CompletedTask);

        var handler = new SendRandomUserToWebhookCommandHandler(mockService.Object);
        var command = new SendRandomUserToWebhookCommand
        {
            WebhookId = "123"
        };

        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().BeTrue();
        mockService.Verify(s => s.GetAndMapRandomUserAsync(), Times.Once);
        mockService.Verify(s => s.SendToWebhookAsync(payload, "123"), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_Return_False_When_Payload_Is_Null()
    {
        var mockService = new Mock<IRandomUserService>();
        mockService.Setup(s => s.GetAndMapRandomUserAsync())
                   .ReturnsAsync((RandomUserWebhookPayload?)null);

        var handler = new SendRandomUserToWebhookCommandHandler(mockService.Object);
        var command = new SendRandomUserToWebhookCommand { WebhookId = "123" };

        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().BeFalse();
        mockService.Verify(s => s.SendToWebhookAsync(It.IsAny<RandomUserWebhookPayload>(), It.IsAny<string>()), Times.Never);
    }
}
