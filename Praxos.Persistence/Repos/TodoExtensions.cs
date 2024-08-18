using Praxos.Application.Models;

namespace Praxos.Persistence.Repos;

public static class TodoExtensions
{
    public static TodoDb MapToDb(this Todo entity)
    {
        return new TodoDb()
        {
            Id = entity.Id,
            Item = entity.Item,
        };
    }

    public static Todo MapToDomain(this TodoDb entity)
    {
        return new Todo(entity.Item, entity.Id);
    }
}