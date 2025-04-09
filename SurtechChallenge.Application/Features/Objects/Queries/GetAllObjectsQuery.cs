
using MediatR;
using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Application.Features.Objects.Queries;

public class GetAllObjectsQuery : IRequest<IEnumerable<ApiObject>>
{
}

