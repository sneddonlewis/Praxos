using AutoMapper;
using Praxos.Application.Models.Mapping;

namespace Praxos.Api.Controllers.ViewModels.Mapping;

public static class ControllerMapper
{
    static ControllerMapper()
    {
        Mapper = new MapperFactory<ControllerProfile>().Mapper;
    }
    
    public static IMapper Mapper { get; private set; }
}