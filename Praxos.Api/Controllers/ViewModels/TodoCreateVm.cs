using Praxos.Application.Models;

namespace Praxos.Api.Controllers.ViewModels;

public record TodoCreateVm(string Item);

public static class TodoCreateVmExtensions
{
    public static Todo ToDomain(this TodoCreateVm createVm)
    {
        return new Todo(createVm.Item);
    }
}