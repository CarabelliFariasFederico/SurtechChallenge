using MediatR;
using SurtechChallenge.Application.Interfaces;
using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Application.Features.Objects.Queries;

public class GetAllObjectsQueryHandler : IRequestHandler<GetAllObjectsQuery, IEnumerable<ApiObject>>
{
    private readonly IRestfulApiService _apiService;

    public GetAllObjectsQueryHandler(IRestfulApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IEnumerable<ApiObject>> Handle(GetAllObjectsQuery request, CancellationToken cancellationToken)
    {
        return await _apiService.GetAllAsync();
    }
}
