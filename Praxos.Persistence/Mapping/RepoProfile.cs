using AutoMapper;
using Praxos.Application.Models;
using Praxos.Persistence.Models;

namespace Praxos.Persistence.Mapping;

public class RepoProfile : Profile
{
    public RepoProfile()
    {
        CreateMap<Todo, TodoDb>().ReverseMap();
    }
}