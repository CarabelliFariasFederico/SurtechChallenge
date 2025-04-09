using MediatR;
using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Application.Features.Objects.Queries;

public class GetObjectByIdQuery : IRequest<ApiObject?>
{
    public string Id { get; set; } = string.Empty;
}
