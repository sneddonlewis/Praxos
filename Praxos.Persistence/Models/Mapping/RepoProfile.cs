using AutoMapper;
using Praxos.Application.Models;

namespace Praxos.Persistence.Models.Mapping;

public class RepoProfile : Profile
{
    public RepoProfile()
    {
        CreateMap<Todo, TodoDb>().ReverseMap();
    }
}