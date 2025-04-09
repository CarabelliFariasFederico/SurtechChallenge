using AutoMapper;
using MediatR;
using SurtechChallenge.Application.Interfaces;
using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Application.Features.Objects.Commands;

public class UpdateObjectCommandHandler : IRequestHandler<UpdateObjectCommand, ApiObject?>
{
    private readonly IRestfulApiService _apiService;
    private readonly IMapper _mapper;

    public UpdateObjectCommandHandler(IRestfulApiService apiService, IMapper mapper)
    {
        _apiService = apiService;
        _mapper = mapper;
    }

    public async Task<ApiObject?> Handle(UpdateObjectCommand request, CancellationToken cancellationToken)
    {
        var updated = _mapper.Map<ApiObject>(request);
        return await _apiService.UpdateAsync(request.Id, updated);
    }
}
