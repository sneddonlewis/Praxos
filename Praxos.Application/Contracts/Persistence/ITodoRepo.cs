using Praxos.Application.Models;

namespace Praxos.Application.Contracts.Persistence;

public interface ITodoRepo
{
    Task<IEnumerable<Todo>> All();
    Task<Todo> Create(Todo entity);
}