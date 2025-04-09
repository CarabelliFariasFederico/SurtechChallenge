using FluentAssertions;
using Moq;
using SurtechChallenge.Application.Features.Objects.Queries;
using SurtechChallenge.Application.Interfaces;
using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Tests.Features.Objects.Queries;

public class GetAllObjectsQueryHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnListOfObjects_WhenServiceReturnsData()
    {
        var mockService = new Mock<IRestfulApiService>();
        mockService.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<ApiObject>
        {
            new ApiObject { Id = "1", Name = "Test", Data = new Dictionary<string, object>() }
        });

        var handler = new GetAllObjectsQueryHandler(mockService.Object);
        var query = new GetAllObjectsQuery();

        var result = await handler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result.First().Id.Should().Be("1");
    }
}
