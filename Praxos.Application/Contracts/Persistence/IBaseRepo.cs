using Praxos.Application.Models;

namespace Praxos.Application.Contracts.Persistence;

public interface IBaseRepo<T> where T : Entity
{
    Task<IEnumerable<T>> All();
    Task<T> Create(T entity);
    Task<IEnumerable<T>> FindById(string id);
}