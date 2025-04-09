

namespace SurtechChallenge.Application.Features.Objects.Queries
{
    using MediatR;
    using SurtechChallenge.Domain.Entities;
    public class GetAllObjectsQuery : IRequest<IEnumerable<ApiObject>>
    {
    }
}
