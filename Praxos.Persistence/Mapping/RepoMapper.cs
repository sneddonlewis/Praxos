using AutoMapper;
using Praxos.Application.Mapping;

namespace Praxos.Persistence.Mapping;

public static class RepoMapper
{
    static RepoMapper()
    {
        Mapper = new MapperFactory<RepoProfile>().Mapper;
    }
    
    public static IMapper Mapper { get; set; }
}