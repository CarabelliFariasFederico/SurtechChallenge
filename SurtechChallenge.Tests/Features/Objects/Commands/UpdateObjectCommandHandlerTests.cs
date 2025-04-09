using AutoMapper;
using FluentAssertions;
using Moq;
using SurtechChallenge.Application.Features.Objects.Commands;
using SurtechChallenge.Application.Interfaces;
using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Tests.Features.Objects.Commands;

public class UpdateObjectCommandHandlerTests
{
    [Fact]
    public async Task Handle_Should_Update_And_Return_Object()
    {
        var command = new UpdateObjectCommand
        {
            Id = "id123",
            Name = "Updated Name",
            Data = new Dictionary<string, object> { { "type", "demo" } }
        };

        var expected = new ApiObject
        {
            Id = "id123",
            Name = "Updated Name",
            Data = command.Data
        };

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(m => m.Map<ApiObject>(command)).Returns(expected);

        var mockService = new Mock<IRestfulApiService>();
        mockService.Setup(s => s.UpdateAsync(command.Id, expected)).ReturnsAsync(expected);

        var handler = new UpdateObjectCommandHandler(mockService.Object, mockMapper.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().NotBeNull();
        result!.Id.Should().Be("id123");
        result!.Name.Should().Be("Updated Name");
        mockService.Verify(s => s.UpdateAsync(command.Id, expected), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_Return_Null_When_Api_Returns_Null()
    {
        var command = new UpdateObjectCommand { Id = "id456", Name = "Fail", Data = new() };

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(m => m.Map<ApiObject>(command)).Returns(new ApiObject());

        var mockService = new Mock<IRestfulApiService>();
        mockService.Setup(s => s.UpdateAsync(command.Id, It.IsAny<ApiObject>()))
                   .ReturnsAsync((ApiObject?)null);

        var handler = new UpdateObjectCommandHandler(mockService.Object, mockMapper.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().BeNull();
    }
}
