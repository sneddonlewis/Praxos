namespace Praxos.Persistence.Models.BaseModels;

public static class EntityExtensions
{
    public static T GenerateId<T>(this T entity) where T : EntityDb
    {
        entity.Id = Guid.NewGuid().ToString();
        return entity;
    }
}