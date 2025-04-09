using MediatR;
using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Application.Features.Objects.Commands;

public class CreateObjectCommand : IRequest<ApiObject>
{
    public string Name { get; set; } = string.Empty;
    public Dictionary<string, object> Data { get; set; } = new();
}
