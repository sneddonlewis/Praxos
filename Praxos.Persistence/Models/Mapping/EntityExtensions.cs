using Praxos.Application.Models;
using Praxos.Persistence.Models.BaseModels;

namespace Praxos.Persistence.Models.Mapping;

public static class EntityExtensions
{
    public static T GenerateId<T>(this T entity) where T : DbEntity
    {
        entity.Id = Guid.NewGuid().ToString();
        return entity;
    }
    
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