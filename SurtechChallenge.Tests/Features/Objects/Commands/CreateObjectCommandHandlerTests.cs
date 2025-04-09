using Moq;
using SurtechChallenge.Application.Features.Objects.Commands;
using SurtechChallenge.Application.Interfaces;
using SurtechChallenge.Domain.Entities;
using FluentAssertions;
using AutoMapper;

namespace SurtechChallenge.Tests.Features.Objects.Commands;

public class CreateObjectCommandHandlerTests
{
    [Fact]
    public async Task Handle_Should_Call_CreateAsync_And_Return_Result()
    {
        var command = new CreateObjectCommand
        {
            Name = "Test Object",
            Data = new Dictionary<string, object> { { "key", "value" } }
        };

        var mappedObject = new ApiObject
        {
            Name = command.Name,
            Data = command.Data
        };

        var expectedObject = new ApiObject
        {
            Id = "123",
            Name = command.Name,
            Data = command.Data
        };

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(m => m.Map<ApiObject>(command)).Returns(mappedObject);

        var mockService = new Mock<IRestfulApiService>();
        mockService.Setup(s => s.CreateAsync(mappedObject)).ReturnsAsync(expectedObject);

        var handler = new CreateObjectCommandHandler(mockService.Object, mockMapper.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().NotBeNull();
        result.Id.Should().Be("123");
        result.Name.Should().Be("Test Object");
        result.Data.Should().ContainKey("key");

        mockService.Verify(s => s.CreateAsync(mappedObject), Times.Once);
        mockMapper.Verify(m => m.Map<ApiObject>(command), Times.Once);
    }
}
