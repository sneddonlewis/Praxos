namespace Praxos.Application.Models;

public static class EntityExtensions
{
    public static T GenerateId<T>(this T entity) where T : Entity
    {
        return entity with { Id = Guid.NewGuid().ToString() };
    }
}