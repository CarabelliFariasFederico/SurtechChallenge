using MediatR;
using SurtechChallenge.Application.Interfaces;
using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Application.Features.Objects.Queries;

public class GetObjectByIdQueryHandler : IRequestHandler<GetObjectByIdQuery, ApiObject?>
{
    private readonly IRestfulApiService _apiService;

    public GetObjectByIdQueryHandler(IRestfulApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<ApiObject?> Handle(GetObjectByIdQuery request, CancellationToken cancellationToken)
    {
        return await _apiService.GetByIdAsync(request.Id);
    }
}
