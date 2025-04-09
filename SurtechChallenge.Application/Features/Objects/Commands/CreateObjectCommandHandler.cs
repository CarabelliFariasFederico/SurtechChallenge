using AutoMapper;
using MediatR;
using SurtechChallenge.Application.Interfaces;
using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Application.Features.Objects.Commands;

public class CreateObjectCommandHandler : IRequestHandler<CreateObjectCommand, ApiObject>
{
    private readonly IRestfulApiService _apiService;
    private readonly IMapper _mapper;

    public CreateObjectCommandHandler(IRestfulApiService apiService, IMapper mapper)
    {
        _apiService = apiService;
        _mapper = mapper;
    }

    public async Task<ApiObject> Handle(CreateObjectCommand request, CancellationToken cancellationToken)
    {
        var obj = _mapper.Map<ApiObject>(request);
        return await _apiService.CreateAsync(obj);
    }
}
