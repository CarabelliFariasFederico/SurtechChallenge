using AutoMapper;
using SurtechChallenge.Application.Features.Objects.Commands;
using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Application.Mappings;

public class ObjectProfile : Profile
{
    public ObjectProfile()
    {
        CreateMap<CreateObjectCommand, ApiObject>();
        CreateMap<UpdateObjectCommand, ApiObject>();
    }
}
