using Praxos.Application.Contracts.Persistence;
using Praxos.Application.Models;

namespace Praxos.Persistence.Repos;

public class TodoRepo : ITodoRepo
{
    public Task<IEnumerable<Todo>> All()
    {
        throw new NotImplementedException();
    }

    public Task<Todo> Create(Todo entity)
    {
        entity = entity.GenerateId();
        throw new NotImplementedException();
    }
}