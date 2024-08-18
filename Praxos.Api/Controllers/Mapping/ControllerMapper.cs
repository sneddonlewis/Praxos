using AutoMapper;
using Praxos.Application.Mapping;

namespace Praxos.Api.Controllers.Mapping;

public static class ControllerMapper
{
    static ControllerMapper()
    {
        Mapper = new MapperFactory<ControllerProfile>().Mapper;
    }
    
    public static IMapper Mapper { get; private set; }
}