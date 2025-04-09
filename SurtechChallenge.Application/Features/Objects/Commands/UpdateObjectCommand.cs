using MediatR;
using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Application.Features.Objects.Commands;

public class UpdateObjectCommand : IRequest<ApiObject?>
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Dictionary<string, object> Data { get; set; } = new();
}