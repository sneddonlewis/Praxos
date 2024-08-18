using Praxos.Application.Models;
using Praxos.Persistence.Models.BaseModels;

namespace Praxos.Persistence.Models.Mapping;

public static class EntityExtensions
{
    public static T GenerateId<T>(this T entity) where T : EntityDb
    {
        entity.Id = Guid.NewGuid().ToString();
        return entity;
    }
    
    public static TodoEntityDb MapToDb(this Todo entity)
    {
        return new TodoEntityDb()
        {
            Id = entity.Id,
            Item = entity.Item,
        };
    }

    public static Todo MapToDomain(this TodoEntityDb entity)
    {
        return new Todo(entity.Item, entity.Id);
    }

}