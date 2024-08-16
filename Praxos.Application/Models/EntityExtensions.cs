namespace Praxos.Application.Models;

public static class EntityExtensions
{
    public static T GenerateId<T>(this T entity) where T : Entity
    {
        entity.Id = Guid.NewGuid().ToString();
        return entity;
    }
}