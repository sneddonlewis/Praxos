using AutoMapper;
using Praxos.Application.Models.Mapping;

namespace Praxos.Persistence.Models.Mapping;

public static class RepoMapper
{
    static RepoMapper()
    {
        Mapper = new MapperFactory<RepoProfile>().Mapper;
    }
    
    public static IMapper Mapper { get; set; }
}