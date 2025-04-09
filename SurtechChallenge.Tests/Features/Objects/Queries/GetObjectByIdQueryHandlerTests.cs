using FluentAssertions;
using Moq;
using SurtechChallenge.Application.Features.Objects.Queries;
using SurtechChallenge.Application.Interfaces;
using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Tests.Features.Objects.Queries;

public class GetObjectByIdQueryHandlerTests
{
    [Fact]
    public async Task Handle_Should_Return_Object_When_Found()
    {
        var expected = new ApiObject
        {
            Id = "abc123",
            Name = "Test Object",
            Data = new Dictionary<string, object> { { "key", "value" } }
        };

        var mockService = new Mock<IRestfulApiService>();
        mockService.Setup(s => s.GetByIdAsync("abc123"))
                   .ReturnsAsync(expected);

        var handler = new GetObjectByIdQueryHandler(mockService.Object);

        var result = await handler.Handle(new GetObjectByIdQuery { Id = "abc123" }, CancellationToken.None);

        result.Should().NotBeNull();
        result!.Id.Should().Be("abc123");
    }

    [Fact]
    public async Task Handle_Should_Return_Null_When_Not_Found()
    {
        var mockService = new Mock<IRestfulApiService>();
        mockService.Setup(s => s.GetByIdAsync("xyz")).ReturnsAsync((ApiObject?)null);

        var handler = new GetObjectByIdQueryHandler(mockService.Object);

        var result = await handler.Handle(new GetObjectByIdQuery { Id = "xyz" }, CancellationToken.None);

        result.Should().BeNull();
    }
}
