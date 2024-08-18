using Praxos.Application.Models;

namespace Praxos.Api.Controllers.ViewModels.Mapping;

public static class ViewModelMappingExtensions
{
    public static Todo ToDomain(this TodoCreateVm createVm)
    {
        return new Todo(createVm.Item);
    }   
}