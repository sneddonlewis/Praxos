using AutoMapper;
using Praxos.Application.Models;

namespace Praxos.Api.Controllers.ViewModels.Mapping;

public class ControllerProfile : Profile
{
    public ControllerProfile()
    {
        CreateMap<TodoCreateVm, Todo>();
    }
}