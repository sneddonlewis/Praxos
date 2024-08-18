using AutoMapper;
using Praxos.Api.Controllers.V1.ViewModels;
using Praxos.Application.Models;

namespace Praxos.Api.Controllers.Mapping;

public class ControllerProfile : Profile
{
    public ControllerProfile()
    {
        CreateMap<TodoCreateVm, Todo>();
    }
}